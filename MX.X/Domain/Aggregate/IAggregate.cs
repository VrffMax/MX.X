using System.Threading.Tasks;

namespace MX.X.Domain.Aggregate
{
    public interface IAggregate<T, P, R>
        where T : AggregateCommand<P, R>
    {
        Task<R> HandleAsync(T aggregate);
    }
}