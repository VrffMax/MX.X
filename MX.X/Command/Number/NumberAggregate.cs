using System.Linq;
using System.Threading.Tasks;
using MX.X.Domain.Aggregate;

namespace MX.X.Command.Number
{
    public class NumberAggregate
        : Aggregate<NumberAggregateCommand, int, int>
    {
        public override Task<int> HandleAsync(NumberAggregateCommand aggregate) =>
            Task.FromResult(aggregate.Values.Sum());
    }
}