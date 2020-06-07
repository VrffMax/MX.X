using MX.X.Command;
using MX.X.Rule;

namespace MX.X.CommandRule
{
    public class NumberRule
        : Rule<NumberCommand>
    {
        public NumberRule()
            : base(@"(\s*[+-]?\s*[1-9]\d*)+\s*")
        {
        }
    }
}