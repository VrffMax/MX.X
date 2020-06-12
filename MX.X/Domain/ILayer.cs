using System.Threading.Tasks;

namespace MX.X.Domain
{
    public interface ILayer
    {
        Task<(string expression, bool next)> NextAsync(string expression);
    }
}