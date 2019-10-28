using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nestor.Core.Database;
using Nestor.Core.Dto;
using Nestor.Core.Providers;
using Nestor.Core.Services;
using Nestor.Data;
using Nestor.Utils;

namespace Nestor
{
    public class Nestor : IDisposable
    {
        private readonly ILogger<Nestor> _logger;
        private readonly INestProvider _nestProvider;
        private readonly INotifierService _notifierService;
        private readonly IRepository<Nest> _nestRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        private bool _disposed;

        public Nestor(ILogger<Nestor> logger, INestProvider nestProvider, INotifierService notifierService,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _nestProvider = nestProvider;
            _notifierService = notifierService;
            _nestRepository = unitOfWork.GetRepository<Nest>();
            _unitOfWork = unitOfWork;
        }

        public async Task ProcessNests()
        {
            var (unknown, updated) = await GetUnknownAndUpdatedNests();
            ProcessNests(unknown, updated);
            var nestInfos = unknown.Concat(updated).Select(n => n.MapToNestInfoDto());
            await nestInfos.ForEachAsync(_notifierService.Notify);
        }

        private async Task<(IReadOnlyList<Nest> unknown, IReadOnlyList<Nest> updated)> GetUnknownAndUpdatedNests()
        {
            var result = (unknown: new List<Nest>(), updated: new List<Nest>());

            try
            {
                var silphNests = (await _nestProvider.GetNests()).ToList();

                if (!silphNests.Any()) return result;

                var migrationNumber = await _nestProvider.GetMigrationNumber();

                var silphNestsIds = silphNests.Select(n => n.Id);
                var dbNests = GetNestsFromDb(silphNestsIds);

                var nestDataPairs = dbNests.Select(dbn =>
                    (dbNest: dbn, silphNest: silphNests.FirstOrDefault(sn => sn.Id == dbn.Id)));

                result.unknown = silphNests.Where(sn => dbNests.All(dbn => dbn.Id != sn.Id))
                    .Select(n => n.MapToNest(migrationNumber)).ToList();
                result.updated = nestDataPairs.Where(pair => IsOutdated(pair.dbNest, pair.silphNest, migrationNumber))
                    .Select(pair => pair.silphNest.MapToNest(pair.dbNest, migrationNumber)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting missed and outdated nests");
            }

            return result;
        }

        private void ProcessNests(IReadOnlyCollection<Nest> unknown, IReadOnlyCollection<Nest> updated)
        {
            if (unknown.Any()) _nestRepository.CreateMany(unknown);
            if (updated.Any()) _nestRepository.UpdateMany(updated);
            _unitOfWork.SaveChanges();
        }

        private static bool IsOutdated(Nest dbNest, NestDto silphNest, int migrationNumber)
        {
            return dbNest.PokemonId != silphNest.PokemonId || dbNest.LastMigration != migrationNumber;
        }

        private IReadOnlyList<Nest> GetNestsFromDb(IEnumerable<int> nestsIds)
        {
            return _nestRepository
                .Include(e => e.Pokemon)
                .Where(e => nestsIds.Contains(e.Id))
                .AsNoTracking()
                .ToList();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;
            if (disposing)
            {
                _nestRepository?.Dispose();
                _unitOfWork?.Dispose();
            }
        }
    }
}