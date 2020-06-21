using System.Threading.Tasks;

namespace MX.X.Domain.Embed
{
    public interface IEmbed<TEmbedCommand, TAggregateResult>
        where TEmbedCommand : EmbedCommand<TAggregateResult>
    {
        Task<string> EmbedAsync(TEmbedCommand embed);
    }
}