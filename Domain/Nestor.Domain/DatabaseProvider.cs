using Nestor.Contracts.Settings;
using Nestor.Domain.Contracts;

namespace Nestor.Domain
{
	public class DatabaseProvider : IDatabaseProvider
	{
		private readonly NestorContext _context;
		private INestInfoRepository _nestsInfoRepository;
		private INestRepository _nestsRepository;
		private INestUpdateRepository _nestsUpdatesRepository;
		private IPokemonRepository _pokemonsRepository;

		internal DatabaseProvider(IDbSettings dbSettings)
		{
			_context = new NestorContext(dbSettings);
		}

		public INestInfoRepository NestsInfoRepository => _nestsInfoRepository ?? (_nestsInfoRepository = new NestInfoRepository(_context));

		public INestRepository NestsRepository => _nestsRepository ?? (_nestsRepository = new NestRepository(_context));

		public INestUpdateRepository NestsUpdatesRepository => _nestsUpdatesRepository ?? (_nestsUpdatesRepository = new NestUpdateRepository(_context));

		public IPokemonRepository PokemonsRepository => _pokemonsRepository ?? (_pokemonsRepository = new PokemonRepository(_context));

		public void Dispose()
		{
			_context.Dispose();
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}