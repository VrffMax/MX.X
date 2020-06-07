using MX.X.Domain.Split;

namespace MX.X.Command.Number
{
    public class NumberSplitCommandHandler
        : SplitCommandHandler<NumberSplitCommand, int>
    {
        public NumberSplitCommandHandler(ISplit<NumberSplitCommand, int> split)
            : base(split)
        {
        }
    }
}