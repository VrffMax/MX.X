using System.Collections.Generic;
using MediatR;

namespace MX.X.Domain.Aggregate
{
    public abstract class AggregateCommand<P, R>
        : IRequest<R>
    {
        public IEnumerable<P> Values { get; set; }
    }
}