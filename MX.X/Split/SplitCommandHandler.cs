using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MX.X.Split
{
    public abstract class SplitCommandHandler<T, R>
        : IRequestHandler<T, IEnumerable<R>> where T : SplitCommand<R>
    {
        private readonly ISplit<T, R> _split;

        public SplitCommandHandler(ISplit<T, R> split) =>
            _split = split;

        public Task<IEnumerable<R>> Handle(T request, CancellationToken cancellationToken) =>
            _split.Match(request);
    }
}