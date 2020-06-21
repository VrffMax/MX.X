using System.Threading.Tasks;

namespace MX.X.Domain
{
    public interface ILayer
    {
        Task<string> NextAsync(string expression);
    }
}