using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nestor.Core.Dto;
using Nestor.Core.Providers;
using Nestor.Core.Services;
using Nestor.Data;
using Nestor.Utils;

[assembly: InternalsVisibleTo("Nestor.Tests")]

namespace Nestor
{
    public class Nestor : IDisposable
    {
        private readonly ILogger<Nestor> _logger;
        private readonly INestEntityService _nestEntityService;
        private readonly INestProvider _nestProvider;
        private readonly INotifierService _notifierService;

        public Nestor(ILogger<Nestor> logger, INestProvider nestProvider, INestEntityService nestEntityService,
            INotifierService notifierService)
        {
            _logger = logger;
            _nestProvider = nestProvider;
            _nestEntityService = nestEntityService;
            _notifierService = notifierService;
        }

        public async Task ProcessNests()
        {
            try
            {
                var (unknown, updated) = await GetUnknownAndUpdatedNests();
                ProcessNests(unknown, updated);
                await NotifyAboutNests(unknown.Concat(updated));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Nestor runtime error");
            }
        }

        public void Dispose()
        {
            _nestEntityService?.Dispose();
        }

        private static bool IsOutdated(Nest dbNest, NestDto silphNest, int migrationNumber)
        {
            return dbNest.PokemonId != silphNest.PokemonId || dbNest.LastMigration != migrationNumber;
        }

        private async Task<(IReadOnlyList<Nest> unknown, IReadOnlyList<Nest> updated)> GetUnknownAndUpdatedNests()
        {
            var result = (unknown: new List<Nest>(), updated: new List<Nest>());

            try
            {
                var silphNests = (await _nestProvider.GetNests()).ToList();

                if (!silphNests.Any()) return result;

                var migrationNumber = await _nestProvider.GetMigrationNumber();

                if (migrationNumber == default) return result;

                var silphNestsIds = silphNests.Select(n => n.Id);
                var dbNests = _nestEntityService.GetNests(silphNestsIds).ToList();

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

        private async Task NotifyAboutNests(IEnumerable<Nest> nests)
        {
            var nestsIds = nests.Select(n => n.Id);
            var nestInfos = _nestEntityService.GetNestInfoDtos(nestsIds);
            await nestInfos.ForEachAsync(_notifierService.Notify);
        }

        private void ProcessNests(IReadOnlyCollection<Nest> unknown, IReadOnlyCollection<Nest> updated)
        {
            if (!unknown.Any() && !updated.Any())
            {
                return;
            }

            if (unknown.Any())
            {
                _nestEntityService.CreateMany(unknown);
            }

            if (updated.Any())
            {
                _nestEntityService.UpdateMany(updated);
            }
        }
    }
}