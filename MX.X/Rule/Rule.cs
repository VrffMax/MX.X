using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MX.X.Rule
{
    public abstract class Rule<T>
        : IRule<T> where T : RuleCommand
    {
        private readonly Regex _regex;

        public Rule(string pattern) =>
            _regex = new Regex($"^{pattern}$", RegexOptions.Compiled);

        public Task<bool> IsMatch(T rule) =>
            Task.FromResult(_regex.IsMatch(rule.Expression));
    }
}