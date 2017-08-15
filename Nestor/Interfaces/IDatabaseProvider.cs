using System;

namespace Nestor.Interfaces
{
    /// <summary>
    /// Represent 'Unit of Work' Interface
    /// </summary>
    public interface IDatabaseProvider : IDisposable
    {
        INestRepository NestsRepository { get; }
        INestInfoRepository NestsInfoRepository { get; }
        IPokemonRepository PokemonsRepository { get; }
        void Save();
    }
}
