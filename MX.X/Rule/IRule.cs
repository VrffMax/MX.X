using System.Threading.Tasks;

namespace MX.X.Rule
{
    public interface IRule<T>
        where T : RuleCommand
    {
        Task<bool> IsMatch(T ruleCommand);
    }
}