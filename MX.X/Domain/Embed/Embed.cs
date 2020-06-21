using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MX.X.Domain.Embed
{
    public abstract class Embed<TEmbedCommand, TAggregateResult>
        : IEmbed<TEmbedCommand, TAggregateResult> where TEmbedCommand : EmbedCommand<TAggregateResult>
    {
        private readonly Regex _regex;

        public Embed(string pattern) =>
            _regex = new Regex(pattern, RegexOptions.Compiled);

        public Task<string> EmbedAsync(TEmbedCommand embed)
        {
            var queue = new Queue<TAggregateResult>(embed.Values);
            var result = _regex.Replace(embed.Expression, delegate (Match match)
            {
                return queue.Dequeue().ToString();
            });

            return Task.FromResult(result);
        }
    }
}