using System.Threading.Tasks;

namespace MX.X.Domain.Aggregate
{
    public abstract class Aggregate<T, P, R>
        : IAggregate<T, P, R> where T : AggregateCommand<P, R>
    {
        public abstract Task<R> HandleAsync(T aggregate);
    }
}