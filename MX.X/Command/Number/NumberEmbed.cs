using MX.X.Domain.Embed;

namespace MX.X.Command.Number
{
    public class NumberEmbed
        : Embed<NumberEmbedCommand, int>
    {
        public NumberEmbed()
            : base(@"(\s*[+-]?\s*[1-9]\d*)+\s*")
        {
        }
    }
}