using System.Collections.Generic;
using System.Threading.Tasks;

namespace MX.X.Domain.Split
{
    public interface ISplit<T, R>
        where T : SplitCommand<R>
    {
        Task<IEnumerable<R>> SplitAsync(T split);
    }
}