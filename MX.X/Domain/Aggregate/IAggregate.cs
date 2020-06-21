using System.Threading.Tasks;

namespace MX.X.Domain.Aggregate
{
    public interface IAggregate<TAggregateCommand, TSplitResult, TAggregateResult>
        where TAggregateCommand : AggregateCommand<TSplitResult, TAggregateResult>
    {
        Task<TAggregateResult> AggregateAsync(TAggregateCommand aggregate);
    }
}