using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nestor.Core.Database;
using Nestor.Core.Dto;
using Nestor.Core.Services;
using Nestor.Data;
using Nestor.Utils;

namespace Nestor.Services
{
    public class NestEntityService : INestEntityService
    {
        private readonly IRepository<Nest> _nestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NestEntityService(IUnitOfWork unitOfWork)
        {
            _nestRepository = unitOfWork.GetRepository<Nest>();
            _unitOfWork = unitOfWork;
        }

        public void CreateMany(IEnumerable<Nest> nests)
        {
            _nestRepository.CreateMany(nests);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Nest> GetNests(IEnumerable<int> ids)
        {
            return _nestRepository
                .Where(e => ids.Contains(e.Id))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<NestInfoDto> GetNestInfoDtos(IEnumerable<int> ids)
        {
            return _nestRepository
                .Include(e => e.Pokemon)
                .Where(e => ids.Contains(e.Id))
                .Select(n => new NestInfoDto
                {
                    Id = n.Id,
                    IsRecommended = n.IsRecommended,
                    HashtagName = n.HashtagName,
                    LastMigration = n.LastMigration,
                    Lat = n.Lat,
                    Lng = n.Lng,
                    Name = n.Name,
                    NestType = n.NestType.GetNestTypeDescription(),
                    Pokemon = new PokemonDto
                    {
                        Id = n.Pokemon.Id,
                        Name = n.Pokemon.Name
                    }
                })
                .AsNoTracking()
                .ToList();
        }

        public void UpdateMany(IEnumerable<Nest> nests)
        {
            _nestRepository.UpdateMany(nests);
            _unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            _nestRepository?.Dispose();
            _unitOfWork?.Dispose();
        }
    }
}