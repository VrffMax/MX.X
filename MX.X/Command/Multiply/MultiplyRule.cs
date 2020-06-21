using MX.X.Domain.Rule;

namespace MX.X.Command.Multiply
{
    public class MultiplyRule
        : Rule<MultiplyRuleCommand>
    {
        public MultiplyRule()
            : base(@"(\s*[+-]?\s*[1-9]\d*\s*)([*/]\s*[+-]?\s*[1-9]\d*\s*)+")
        {
        }
    }
}