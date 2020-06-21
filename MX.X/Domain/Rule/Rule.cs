using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MX.X.Domain.Rule
{
    public abstract class Rule<TRuleCommand>
        : IRule<TRuleCommand> where TRuleCommand : RuleCommand
    {
        private readonly Regex _regex;

        public Rule(string pattern) =>
            _regex = new Regex(pattern, RegexOptions.Compiled);

        public Task<IEnumerable<string>> ExtractAsync(TRuleCommand rule) =>
            Task.FromResult(_regex.Matches(rule.Expression).Select(match => match.Value).ToArray().AsEnumerable());
    }
}