using System.Linq;
using System.Threading.Tasks;
using MX.X.Domain.Aggregate;
using static MX.X.Command.Multiply.MultiplySplitCommand;
using static MX.X.Command.Multiply.MultiplySplitCommand.MultiplyItem;

namespace MX.X.Command.Multiply
{
    public class MultiplyAggregate
        : Aggregate<MultiplyAggregateCommand, MultiplyItem, int>
    {
        public override Task<int> HandleAsync(MultiplyAggregateCommand aggregate) =>
            Task.FromResult(aggregate.Values.Aggregate((a, b) =>
                b.Operation switch
                {
                    OperationType.Multiply => new MultiplyItem
                    {
                        Number = a.Number * b.Number
                    },
                    OperationType.Divide => new MultiplyItem
                    {
                        Number = a.Number / b.Number
                    },
                    _ => new MultiplyItem
                    {
                        Number = a.Number * b.Number
                    }
                }).Number);
    }
}