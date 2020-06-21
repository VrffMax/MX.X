using MX.X.Domain.Rule;
using MX.X.Domain.Aggregate;
using MX.X.Domain.Split;
using MediatR;
using System.Threading.Tasks;
using System.Linq;

namespace MX.X.Domain
{
    public abstract class Layer<R, S, A, SR, AR>
        : ILayer
        where R : RuleCommand, new()
        where S : SplitCommand<SR>, new()
        where A : AggregateCommand<SR, AR>, new()
    {
        private readonly IMediator _mediator;

        public Layer(IMediator mediator) =>
            _mediator = mediator;

        public async Task<string> NextAsync(string expression)
        {
            var expressions = await _mediator.Send(new R() { Expression = expression });

            var tasks = expressions.Select(async expression =>
            {
                var values = await _mediator.Send(new S() { Expression = expression });
                var result = await _mediator.Send(new A() { Values = values });

                return result;
            }).ToArray();

            var results = await Task.WhenAll(tasks);

            return string.Empty;
        }
    }
}