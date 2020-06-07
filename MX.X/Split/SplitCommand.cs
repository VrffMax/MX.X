using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace MX.X.Split
{
    public abstract class SplitCommand<R>
        : IRequest<IEnumerable<R>>
    {
        public string Expression { get; set; }

        public abstract Task<R> MapItemAsync(string value);
    }
}