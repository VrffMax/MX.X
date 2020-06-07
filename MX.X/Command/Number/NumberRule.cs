using MX.X.Rule;

namespace MX.X.Command.Number
{
    public class NumberRule
        : Rule<NumberRuleCommand>
    {
        public NumberRule()
            : base(@"(\s*[+-]?\s*[1-9]\d*)+\s*")
        {
        }
    }
}