using Nestor.Interfaces;

namespace Nestor.DAL
{
    public class DatabaseProvider : IDatabaseProvider
    {
        private readonly NestsContext _context;
        private INestRepository _nestsRepository;
        private INestInfoRepository _nestsInfoRepository;
        private IPokemonRepository _pokemonsRepository;

        public DatabaseProvider(string connectionString)
        {
            _context = new NestsContext(connectionString);
        }

        public INestInfoRepository NestsInfoRepository => _nestsInfoRepository ?? (_nestsInfoRepository = new NestInfoRepository(_context));

	    public INestRepository NestsRepository => _nestsRepository ?? (_nestsRepository = new NestRepository(_context));

	    public IPokemonRepository PokemonsRepository => _pokemonsRepository ?? (_pokemonsRepository = new PokemonRepository(_context));

	    public void Save()
	    {
			_context.SaveChanges();
        }

        public void Dispose()
        {
	        _context?.Dispose();
        }
    }
}
