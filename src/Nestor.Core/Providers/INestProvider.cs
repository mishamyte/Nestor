using System.Collections.Generic;
using System.Threading.Tasks;
using Nestor.Core.Dto;

namespace Nestor.Core.Providers
{
    public interface INestProvider
    {
        Task<int> GetMigrationNumber();
        
        Task<IEnumerable<NestDto>> GetNests();
    }
}