using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MX.X.Domain.Split
{
    public abstract class SplitCommandHandler<TSplitCommand, TSplitResult>
        : IRequestHandler<TSplitCommand, IEnumerable<TSplitResult>> where TSplitCommand : SplitCommand<TSplitResult>
    {
        private readonly ISplit<TSplitCommand, TSplitResult> _split;

        public SplitCommandHandler(ISplit<TSplitCommand, TSplitResult> split) =>
            _split = split;

        public Task<IEnumerable<TSplitResult>> Handle(TSplitCommand request, CancellationToken cancellationToken) =>
            _split.SplitAsync(request);
    }
}