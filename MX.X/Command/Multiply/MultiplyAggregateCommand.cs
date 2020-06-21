using MX.X.Domain.Aggregate;
using static MX.X.Command.Multiply.MultiplySplitCommand;

namespace MX.X.Command.Multiply
{
    public class MultiplyAggregateCommand
        : AggregateCommand<MultiplyItem, int>
    {
    }
}