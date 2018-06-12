﻿using System;

namespace Nestor.DAL.Interfaces
{
    /// <summary>
    /// Represent 'Unit of Work' Interface
    /// </summary>
    internal interface IDatabaseProvider : IDisposable
    {
		INestInfoRepository NestsInfoRepository { get; }

		INestRepository NestsRepository { get; }

	    INestUpdateRepository NestsUpdatesRepository { get; }

		IPokemonRepository PokemonsRepository { get; }

        void Save();
    }
}