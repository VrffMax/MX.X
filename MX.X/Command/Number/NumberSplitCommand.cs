using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MX.X.Split;

namespace MX.X.Command.Number
{
    public class NumberSplitCommand
        : SplitCommand<int>
    {
        private readonly Regex whiteSpaceRegex = new Regex(@"\s+", RegexOptions.Compiled);

        public override Task<int> MapItemAsync(string value) =>
            Task.FromResult(int.Parse(whiteSpaceRegex.Replace(value, string.Empty)));
    }
}