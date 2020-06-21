using MX.X.Domain.Embed;

namespace MX.X.Command.Multiply
{
    public class MultiplyEmbedCommandHandler
        : EmbedCommandHandler<MultiplyEmbedCommand, int>
    {
        public MultiplyEmbedCommandHandler(IEmbed<MultiplyEmbedCommand, int> embed)
            : base(embed)
        {
        }
    }
}