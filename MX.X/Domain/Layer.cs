using MX.X.Domain.Rule;
using MX.X.Domain.Aggregate;
using MX.X.Domain.Split;
using MediatR;
using System.Threading.Tasks;

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

        public async Task<(string expression, bool next)> NextAsync(string expression)
        {
            if (!await _mediator.Send(new R() { Expression = expression }))
            {
                return (expression, false);
            }

            var values = await _mediator.Send(new S() { Expression = expression });
            var result = await _mediator.Send(new A() { Values = values });

            return (result.ToString(), true);
        }
    }
}