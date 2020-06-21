using MX.X.Domain.Embed;

namespace MX.X.Command.Number
{
    public class NumberEmbedCommandHandler
        : EmbedCommandHandler<NumberEmbedCommand, int>
    {
        public NumberEmbedCommandHandler(IEmbed<NumberEmbedCommand, int> embed)
            : base(embed)
        {
        }
    }
}