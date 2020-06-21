using System.Collections.Generic;
using MediatR;

namespace MX.X.Domain.Embed
{
    public abstract class EmbedCommand<TAggregateResult>
        : IExpression, IRequest<string>
    {
        public string Expression { get; set; }

        public IEnumerable<TAggregateResult> Values { get; set; }
    }
}