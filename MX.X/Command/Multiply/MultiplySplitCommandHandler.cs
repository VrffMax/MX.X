using MX.X.Domain.Split;
using static MX.X.Command.Multiply.MultiplySplitCommand;

namespace MX.X.Command.Multiply
{
    public class MultiplySplitCommandHandler
        : SplitCommandHandler<MultiplySplitCommand, MultiplyItem>
    {
        public MultiplySplitCommandHandler(ISplit<MultiplySplitCommand, MultiplyItem> split)
            : base(split)
        {
        }
    }
}