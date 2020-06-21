using MX.X.Domain.Rule;
using MX.X.Domain.Aggregate;
using MX.X.Domain.Split;
using MediatR;
using System.Threading.Tasks;
using System.Linq;
using MX.X.Domain.Embed;

namespace MX.X.Domain
{
    public abstract class Layer<TRuleCommand, TSplitCommand, TAggregateCommand, TEmbedCommand, TSplitResult, TAggregateResult>
        : ILayer
        where TRuleCommand : RuleCommand, new()
        where TSplitCommand : SplitCommand<TSplitResult>, new()
        where TAggregateCommand : AggregateCommand<TSplitResult, TAggregateResult>, new()
        where TEmbedCommand : EmbedCommand<TAggregateResult>, new()
    {
        private readonly IMediator _mediator;

        public Layer(IMediator mediator) =>
            _mediator = mediator;

        public async Task<string> NextAsync(string expression)
        {
            var expressions = await _mediator.Send(new TRuleCommand { Expression = expression });

            var tasks = expressions.Select(async expression =>
            {
                var values = await _mediator.Send(new TSplitCommand { Expression = expression });
                var result = await _mediator.Send(new TAggregateCommand { Values = values });

                return result;
            }).ToArray();

            var results = await Task.WhenAll(tasks);

            var result = await _mediator.Send(new TEmbedCommand
            {
                Expression = expression,
                Values = results
            });

            return result;
        }
    }
}