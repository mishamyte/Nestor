using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nestor.DAL;
using Nestor.DAL.Interfaces;
using Nestor.DTO;
using Nestor.Logging;
using Nestor.Model;
using Nestor.Parser;
using Nestor.Settings;
using NestType = Nestor.DTO.NestType;

namespace Nestor.BusinessLogic
{
	internal class NestsWatcher : INestsWatcher
	{
		private readonly IParser _parser;
		private readonly IGlobalSettings _globalSettings;
		private readonly Func<IDatabaseProvider> _getDbProvider;

		internal NestsWatcher(ISettings settings)
		{
			_parser = new Parser.Parser(new TheSilphRoadProvider(settings.ParserSettings));

			_globalSettings = settings.GlobalSettings;

			_getDbProvider = () => new DatabaseProvider(settings.DbSettings);
		}

		internal NestsWatcher(IGlobalSettings globalSettings, IParser parser, Func<IDatabaseProvider> getDbProvider)
		{
			_parser = parser;

			_globalSettings = globalSettings;

			_getDbProvider = getDbProvider;
		}

		public async Task<IList<NestDto>> GetMissingAndOutdatedNests()
		{
			try
			{
				using (var dbProvider = _getDbProvider())
				{
					var silphNests = await _parser.GetNests();
					var dbNests = dbProvider.NestsRepository.Get().ToList();
					var resultingNests = new List<NestDto>();

					if (silphNests != null)
					{
						foreach (var silphNest in silphNests)
						{
							if (dbNests.Exists(x => x.Id == silphNest.Id))
							{
								var dbNest = dbNests.Find(x => x.Id == silphNest.Id);

								if (dbNest.PokemonId != silphNest.PokemonId ||
									dbNest.LastMigration != _globalSettings.MigrationNumber)
								{
									var finalNest = GetFinalNest(dbNest, silphNest.PokemonId);

									resultingNests.Add(new NestDto
									{
										Nest = finalNest,
										NestType = NestType.Outdated
									});
								}
							}
							else
							{
								var finalNest = GetFinalNest(silphNest, silphNest.PokemonId);

								resultingNests.Add(new NestDto
								{
									Nest = finalNest,
									NestType = NestType.Missed
								});
							}
						}
					}
					else
					{
						Logger.LogDebug("Empty parser response");
					}

					return resultingNests;
				}

			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
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

		public void RecordNestUpdateToHistory(Nest nest)
		{
			try
			{
				using (var dbProvider = _getDbProvider())
				{
					var updateRecord = new NestUpdate
					{
						NestId = nest.Id,
						PokemonId = nest.PokemonId,
						MigrationNumber = _globalSettings.MigrationNumber,
						Timestamp = DateTime.Now
					};

					dbProvider.NestsUpdatesRepository.Insert(updateRecord);
					dbProvider.Save();
					Logger.LogMessage(
						$"Nest {updateRecord.NestId} was updated in {updateRecord.Timestamp} with pokemon: {updateRecord.PokemonId}");
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
				throw;
			}
		}

		public void Dispose()
		{
			_parser.Dispose();
		}

		private void AddNest(Nest nest)
		{
			try
			{
				using (var dbProvider = _getDbProvider())
				{
					dbProvider.NestsRepository.Insert(nest);
					dbProvider.Save();
					Logger.LogMessage($"NEST ADDED: {nest.Id}\t{nest.Pokemon.Name}");
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
				throw;
			}
		}

		private Nest AttachPokemonEntity(Nest nest, int pokemonId)
		{
			try
			{
				using (var dbProvider = _getDbProvider())
				{
					var pokemon = dbProvider.PokemonsRepository.GetById(pokemonId);
					nest.PokemonId = pokemon.Id;
					nest.Pokemon = pokemon;

					return nest;
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
				throw;
			}
		}

		private Nest GetFinalNest(Nest nest, int pokemonId)
		{
			try
			{
				var finalNest = AttachPokemonEntity(nest, pokemonId);
				finalNest.LastMigration = _globalSettings.MigrationNumber;

				return finalNest;
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
				throw;
			}
		}

		private void UpdateNest(Nest nest)
		{
			try
			{
				using (var dbProvider = _getDbProvider())
				{
					dbProvider.NestsRepository.Update(nest);
					dbProvider.Save();
					Logger.LogMessage($"NEST UPDATED: {nest.Id}\t{nest.Pokemon.Name}");
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
				throw;
			}
		}
	}
}
