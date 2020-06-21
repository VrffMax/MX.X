using System.Collections.Generic;
using System.Threading.Tasks;

namespace MX.X.Domain.Split
{
    public interface ISplit<TSplitCommand, TSplitResult>
        where TSplitCommand : SplitCommand<TSplitResult>
    {
        Task<IEnumerable<TSplitResult>> SplitAsync(TSplitCommand split);
    }
}