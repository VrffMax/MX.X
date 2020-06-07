using System.Collections.Generic;
using System.Threading.Tasks;

namespace MX.X.Split
{
    public interface ISplit<T, R>
        where T : SplitCommand<R>
    {
        Task<IEnumerable<R>> Match(T split);
    }
}