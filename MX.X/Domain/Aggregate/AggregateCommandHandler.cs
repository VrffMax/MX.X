using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MX.X.Domain.Aggregate
{
    public abstract class AggregateCommandHandler<TAggregateCommand, TSplitResult, TAggregateResult>
        : IRequestHandler<TAggregateCommand, TAggregateResult> where TAggregateCommand : AggregateCommand<TSplitResult, TAggregateResult>
    {
        private readonly IAggregate<TAggregateCommand, TSplitResult, TAggregateResult> _aggregate;

        public AggregateCommandHandler(IAggregate<TAggregateCommand, TSplitResult, TAggregateResult> aggregate) =>
            _aggregate = aggregate;

        public Task<TAggregateResult> Handle(TAggregateCommand request, CancellationToken cancellationToken) =>
            _aggregate.AggregateAsync(request);
    }
}