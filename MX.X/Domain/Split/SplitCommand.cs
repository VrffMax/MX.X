using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace MX.X.Domain.Split
{
    public abstract class SplitCommand<TSplitResult>
        : IExpression, IRequest<IEnumerable<TSplitResult>>
    {
        public string Expression { get; set; }

        public abstract Task<TSplitResult> MapItemAsync(string value);
    }
}