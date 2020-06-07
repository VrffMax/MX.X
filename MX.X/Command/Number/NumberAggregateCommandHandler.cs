using MX.X.Domain.Aggregate;

namespace MX.X.Command.Number
{
    public class NumberAggregateCommandHandler
        : AggregateCommandHandler<NumberAggregateCommand, int, int>
    {
        public NumberAggregateCommandHandler(IAggregate<NumberAggregateCommand, int, int> aggregate)
            : base(aggregate)
        {
        }
    }
}