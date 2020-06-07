using System.Threading.Tasks;

namespace MX.X.Domain.Rule
{
    public interface IRule<T>
        where T : RuleCommand
    {
        Task<bool> IsMatchAsync(T rule);
    }
}