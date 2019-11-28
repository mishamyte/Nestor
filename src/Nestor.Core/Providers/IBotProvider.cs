using System.Threading.Tasks;

namespace Nestor.Core.Providers
{
    public interface IBotProvider
    {
        Task SendImage(string uri, string caption);
    }
}