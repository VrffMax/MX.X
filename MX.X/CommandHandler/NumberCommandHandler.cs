using MX.X.Command;
using MX.X.Rule;

namespace MX.X.CommandHandler
{
    public class NumberCommandHandler
        : RuleCommandHandler<NumberCommand>
    {
        public NumberCommandHandler(IRule<NumberCommand> rule)
            : base(rule)
        {
        }
    }
}