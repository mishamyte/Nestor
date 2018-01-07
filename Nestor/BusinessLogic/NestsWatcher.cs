using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nestor.DAL;
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
		private readonly ISettings _settings;

		internal NestsWatcher(ISettings settings)
		{
			_parser = new Parser.Parser(new TheSilphRoadProvider(settings.ParserSettings));

			_settings = settings;
		}

		public async Task<IList<NestDto>> GetMissingAndOutdatedNests()
		{
			try
			{
				using (var dbProvider = new DatabaseProvider(_settings.DbSettings))
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
									dbNest.LastMigration != _settings.GlobalSettings.MigrationNumber)
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
		public void Dispose()
		{
			_parser.Dispose();
		}

		private void AddNest(Nest nest)
		{
			try
			{
				using (var dbProvider = new DatabaseProvider(_settings.DbSettings))
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
				using (var dbProvider = new DatabaseProvider(_settings.DbSettings))
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
				finalNest.LastMigration = _settings.GlobalSettings.MigrationNumber;

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
				using (var dbProvider = new DatabaseProvider(_settings.DbSettings))
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
