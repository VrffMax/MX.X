using MX.X.Domain.Split;
using static MX.X.Command.Multiply.MultiplySplitCommand;

namespace MX.X.Command.Multiply
{
    public class MultiplySplit
        : Split<MultiplySplitCommand, MultiplyItem>
    {
        public MultiplySplit()
            : base(@"[*/]?\s*[+-]?\s*[1-9]\d*")
        {
        }
    }
}