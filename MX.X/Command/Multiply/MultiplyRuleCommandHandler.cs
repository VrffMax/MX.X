using MX.X.Domain.Rule;

namespace MX.X.Command.Multiply
{
    public class MultiplyRuleCommandHandler
        : RuleCommandHandler<MultiplyRuleCommand>
    {
        public MultiplyRuleCommandHandler(IRule<MultiplyRuleCommand> rule)
            : base(rule)
        {
        }
    }
}