using System.Collections.Generic;
using MediatR;

namespace MX.X.Domain.Aggregate
{
    public abstract class AggregateCommand<TSplitResult, TAggregateResult>
        : IRequest<TAggregateResult>
    {
        public IEnumerable<TSplitResult> Values { get; set; }
    }
}