using System.Threading.Tasks;

namespace MX.X.Domain.Aggregate
{
    public abstract class Aggregate<TAggregateCommand, TSplitResult, TAggregateResult>
        : IAggregate<TAggregateCommand, TSplitResult, TAggregateResult> where TAggregateCommand : AggregateCommand<TSplitResult, TAggregateResult>
    {
        public abstract Task<TAggregateResult> AggregateAsync(TAggregateCommand aggregate);
    }
}