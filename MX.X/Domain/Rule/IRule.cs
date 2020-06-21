using System.Collections.Generic;
using System.Threading.Tasks;

namespace MX.X.Domain.Rule
{
    public interface IRule<TRuleCommand>
        where TRuleCommand : RuleCommand
    {
        Task<IEnumerable<string>> ExtractAsync(TRuleCommand rule);
    }
}