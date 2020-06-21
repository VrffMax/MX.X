using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MX.X.Domain.Embed
{
    public abstract class EmbedCommandHandler<TEmbedCommand, TAggregateResult>
        : IRequestHandler<TEmbedCommand, string> where TEmbedCommand : EmbedCommand<TAggregateResult>
    {
        private readonly IEmbed<TEmbedCommand, TAggregateResult> _embed;

        public EmbedCommandHandler(IEmbed<TEmbedCommand, TAggregateResult> embed) =>
            _embed = embed;

        public Task<string> Handle(TEmbedCommand request, CancellationToken cancellationToken) =>
            _embed.EmbedAsync(request);
    }
}