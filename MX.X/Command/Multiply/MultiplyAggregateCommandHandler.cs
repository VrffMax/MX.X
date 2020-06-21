using MX.X.Domain.Aggregate;
using static MX.X.Command.Multiply.MultiplySplitCommand;

namespace MX.X.Command.Multiply
{
    public class MultiplyAggregateCommandHandler
        : AggregateCommandHandler<MultiplyAggregateCommand, MultiplyItem, int>
    {
        public MultiplyAggregateCommandHandler(IAggregate<MultiplyAggregateCommand, MultiplyItem, int> aggregate)
            : base(aggregate)
        {
        }
    }
}