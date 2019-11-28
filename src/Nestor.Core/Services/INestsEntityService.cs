using System;
using System.Collections.Generic;
using Nestor.Core.Dto;
using Nestor.Data;

namespace Nestor.Core.Services
{
    public interface INestEntityService : IDisposable
    {
        void CreateMany(IEnumerable<Nest> nests);
        
        IEnumerable<Nest> GetNests(IEnumerable<int> ids);

        IEnumerable<NestInfoDto> GetNestInfoDtos(IEnumerable<int> ids);

        void UpdateMany(IEnumerable<Nest> nests);
    }
}