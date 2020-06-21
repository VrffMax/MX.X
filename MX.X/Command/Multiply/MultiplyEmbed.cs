using MX.X.Domain.Embed;

namespace MX.X.Command.Multiply
{
    public class MultiplyEmbed
        : Embed<MultiplyEmbedCommand, int>
    {
        public MultiplyEmbed()
            : base(@"(\s*[+-]?\s*[1-9]\d*\s*)([*/]\s*[+-]?\s*[1-9]\d*\s*)+")
        {
        }
    }
}