using System.Collections.Generic;
using System.Threading.Tasks;

namespace MX.X.Domain.Rule
{
    public interface IRule<T>
        where T : RuleCommand
    {
        Task<IEnumerable<string>> IsMatchAsync(T rule);
    }
}