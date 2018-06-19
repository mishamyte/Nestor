using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Nestor.Contracts;
using Nestor.Contracts.Dtos;
using Nestor.Domain.Contracts;
using Serilog;
using NestType = Nestor.Contracts.Dtos.NestType;

namespace Nestor
{
	internal class NestsWatcher : INestsWatcher
	{
		private readonly Func<IDatabaseProvider> _getDbProvider;
		private readonly ILogger _logger;
		private readonly IParser _parser;

		public NestsWatcher(IParser parser, Func<IDatabaseProvider> getDbProvider, ILogger logger)
		{
			_parser = parser;
			_getDbProvider = getDbProvider;
			_logger = logger;
		}

		public void Dispose()
		{
			_parser.Dispose();
		}

		public async Task<IList<NestDto>> GetMissingAndOutdatedNests()
		{
			try
			{
				using (var dbProvider = _getDbProvider())
				{
					var migrationNumber = await _parser.GetMigrationNumber();
					var silphNests = await _parser.GetNests();				
					var resultingNests = new List<NestDto>();

					if (silphNests != null)
					{
						var silphNestsIds = silphNests.Select(nest => nest.Id);
						var dbNests = dbProvider.NestsRepository.Get(nest => silphNestsIds.Any(silph => silph == nest.Id)).ToArray();

						foreach (var dbNest in dbNests)
						{
							var silphNest = silphNests.Find(nest => nest.Id == dbNest.Id);

							if (IsOutdated(dbNest, silphNest, migrationNumber))
							{
								var updatedDbNest = Mapper.Map(silphNest, dbNest);
								updatedDbNest.LastMigration = migrationNumber;
								
								resultingNests.Add(new NestDto
								{
									Nest = updatedDbNest,
									NestType = NestType.Outdated
								});
							}						
						}

						var newSilphNests = silphNests.Where(silph => dbNests.All(nest => silph.Id != nest.Id));

						foreach (var newSilphNest in newSilphNests)
						{
							var newDbNest = Mapper.Map<SilphNestDto, Nest>(newSilphNest);
							newDbNest.LastMigration = migrationNumber;

							resultingNests.Add(new NestDto
							{
								Nest = newDbNest,
								NestType = NestType.Missed
							});
						}
					}
					else
					{
						_logger.Warning("Empty parser response");
					}

					return resultingNests;
				}

			}
			catch (Exception ex)
			{
				_logger.Error(ex, "Error while getting missed and outdated nests");
				throw;
			}
		}

		public void ProcessNest(NestDto nestDto)
		{
			switch (nestDto.NestType)
			{
				case NestType.Missed:
					AddNest(nestDto.Nest);
					break;
				case NestType.Outdated:
					UpdateNest(nestDto.Nest);
					break;
				default:
					throw new ArgumentOutOfRangeException($"Unexpected nest type {nestDto.NestType}");
			}
		}

		public void RecordNestUpdateToHistory(NestDto nest)
		{
			try
			{
				using (var dbProvider = _getDbProvider())
				{
					var pokemon = dbProvider.PokemonsRepository.GetById(nest.Nest.PokemonId);

					var updateRecord = new NestUpdate
					{
						NestId = nest.Nest.Id,
						PokemonId = nest.Nest.PokemonId,
						MigrationNumber = nest.Nest.LastMigration,
						Timestamp = DateTime.Now
					};

					dbProvider.NestsUpdatesRepository.Insert(updateRecord);
					dbProvider.Save();

					_logger.Information(
						$"Nest {updateRecord.NestId} was updated in {updateRecord.Timestamp} with pokemon: {pokemon.Name}");
				}
			}
			catch (Exception ex)
			{
				_logger.Error(ex, "Error while recording nest update to history");
				throw;
			}
		}

		private static bool IsOutdated(Nest dbNest, SilphNestDto silphNest, int migrationNumber)
		{
			return dbNest.PokemonId != silphNest.PokemonId || dbNest.LastMigration != migrationNumber;
		}

		private void AddNest(Nest nest)
		{
			try
			{
				using (var dbProvider = _getDbProvider())
				{
					var pokemon = dbProvider.PokemonsRepository.GetById(nest.PokemonId);

					dbProvider.NestsRepository.Insert(nest);
					dbProvider.Save();
					_logger.Information($"NEST ADDED: {nest.Id}\t{pokemon.Name}");
				}
			}
			catch (Exception ex)
			{
				_logger.Error(ex, "Error while adding nest {@Nest}", nest);
				throw;
			}
		}

		private void UpdateNest(Nest nest)
		{
			try
			{
				using (var dbProvider = _getDbProvider())
				{
					var pokemon = dbProvider.PokemonsRepository.GetById(nest.PokemonId);

					dbProvider.NestsRepository.Update(nest);
					dbProvider.Save();
					_logger.Information($"NEST UPDATED: {nest.Id}\t{pokemon.Name}");
				}
			}
			catch (Exception ex)
			{
				_logger.Error(ex, "Error while updating nest {@Nest}", nest);
				throw;
			}
		}
	}
}