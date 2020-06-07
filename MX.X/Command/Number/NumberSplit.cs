using MX.X.Split;

namespace MX.X.Command.Number
{
    public class NumberSplit
        : Split<NumberSplitCommand, int>
    {
        public NumberSplit()
            : base(@"\s*[+-]?\s*[1-9]\d*")
        {
        }
    }
}