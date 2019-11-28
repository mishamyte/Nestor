using System.Threading.Tasks;

namespace Nestor.Core.Services
{
    public interface ITheSilphRoadService
    {
        Task<string> GetLocalNests();
        
        Task<string> GetNestHistory();
    }
}