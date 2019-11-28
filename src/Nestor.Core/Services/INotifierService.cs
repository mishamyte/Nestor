using System.Threading.Tasks;
using Nestor.Core.Dto;

namespace Nestor.Core.Services
{
    public interface INotifierService
    {
        Task Notify(NestInfoDto nest);
    }
}