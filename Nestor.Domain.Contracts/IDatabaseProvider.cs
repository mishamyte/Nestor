using System;

namespace Nestor.Domain.Contracts
{
	public interface IDatabaseProvider : IDisposable
	{
		INestInfoRepository NestsInfoRepository { get; }

		INestRepository NestsRepository { get; }

		INestUpdateRepository NestsUpdatesRepository { get; }

		IPokemonRepository PokemonsRepository { get; }

		void Save();
	}
}