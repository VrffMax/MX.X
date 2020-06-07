using MX.X.Domain.Rule;

namespace MX.X.Command.Number
{
    public class NumberRuleCommandHandler
        : RuleCommandHandler<NumberRuleCommand>
    {
        public NumberRuleCommandHandler(IRule<NumberRuleCommand> rule)
            : base(rule)
        {
        }
    }
}