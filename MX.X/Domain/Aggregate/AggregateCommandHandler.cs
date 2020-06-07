using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MX.X.Domain.Aggregate
{
    public abstract class AggregateCommandHandler<T, P, R>
        : IRequestHandler<T, R> where T : AggregateCommand<P, R>
    {
        private readonly IAggregate<T, P, R> _aggregate;

        public AggregateCommandHandler(IAggregate<T, P, R> aggregate) =>
            _aggregate = aggregate;

        public Task<R> Handle(T request, CancellationToken cancellationToken) =>
            _aggregate.HandleAsync(request);
    }
}