using Nestor.Interfaces;

namespace Nestor.DAL
{
    public class DatabaseProvider : IDatabaseProvider
    {
        private NestsContext context;
        private INestRepository nestsRepository;
        private INestInfoRepository nestsInfoRepository;
        private IPokemonRepository pokemonsRepository;

        public DatabaseProvider(string connectionString)
        {
            context = new NestsContext(connectionString);
        }

        public INestInfoRepository NestsInfoRepository
        {
            get
            {
                if (nestsInfoRepository == null)
                {
                    nestsInfoRepository = new NestInfoRepository(context);
                }
                return nestsInfoRepository;
            }
        }

        public INestRepository NestsRepository
        {
            get
            {
                if (nestsRepository == null)
                {
                    nestsRepository = new NestRepository(context);
                }
                return nestsRepository;
            }
        }

        public IPokemonRepository PokemonsRepository
        {
            get
            {
                if (pokemonsRepository == null)
                {
                    pokemonsRepository = new PokemonRepository(context);
                }
                return pokemonsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
