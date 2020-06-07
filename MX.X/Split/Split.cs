using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MX.X.Split
{
    public abstract class Split<T, R>
        : ISplit<T, R> where T : SplitCommand<R>
    {
        private readonly Regex _regex;

        public Split(string pattern) =>
            _regex = new Regex(pattern, RegexOptions.Compiled);

        public async Task<IEnumerable<R>> Match(T split)
        {
            var matches = _regex.Matches(split.Expression);
            var tasks = matches.Select(match => split.MapItemAsync(match.Value)).ToArray();
            var result = await Task.WhenAll(tasks);

            return result;
        }
    }
}