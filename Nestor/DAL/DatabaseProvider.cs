using Nestor.DAL.Interfaces;
using Nestor.Settings;

namespace Nestor.DAL
{
	internal class DatabaseProvider : IDatabaseProvider
    {
        private readonly NestsContext _context;
		private INestInfoRepository _nestsInfoRepository;
		private INestRepository _nestsRepository;
		private IPokemonRepository _pokemonsRepository;

	    internal DatabaseProvider(IDbSettings dbSettings)
        {
            _context = new NestsContext(dbSettings);
        }

        public INestInfoRepository NestsInfoRepository => _nestsInfoRepository ?? (_nestsInfoRepository = new NestInfoRepository(_context));

	    public INestRepository NestsRepository => _nestsRepository ?? (_nestsRepository = new NestRepository(_context));

	    public IPokemonRepository PokemonsRepository => _pokemonsRepository ?? (_pokemonsRepository = new PokemonRepository(_context));

		public void Dispose()
		{
			_context?.Dispose();
		}

		public void Save()
		{
			_context.SaveChanges();
        }
    }
}
