using System;
using Nestor.Core.Dto;
using Nestor.Data;

namespace Nestor.Utils
{
    public static class MappingHelper
    {
        public static Nest MapToNest(this NestDto source, int migrationNumber)
        {
            return MapToNest(source, new Nest(), migrationNumber);
        }

        public static Nest MapToNest(this NestDto source, Nest destination, int migrationNumber)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

            destination.Id = source.Id;
            destination.PokemonId = source.PokemonId;
            destination.NestType = (NestType) source.NestType;
            destination.Lat = source.Lat;
            destination.Lng = source.Lng;
            destination.LastMigration = migrationNumber;
            destination.NestUpdates.Add(CreateNestUpdate(destination));

            return destination;
        }

        public static NestInfoDto MapToNestInfoDto(this Nest source)
        {
            return new NestInfoDto
            {
                Id = source.Id,
                IsRecommended = source.IsRecommended,
                HashtagName = source.HashtagName,
                LastMigration = source.LastMigration,
                Lat = source.Lat,
                Lng = source.Lng,
                Name = source.Name,
                NestType = source.NestType.GetNestTypeDescription(),
                Pokemon = new PokemonDto
                {
                    Id = source.Pokemon.Id,
                    Name = source.Pokemon.Name
                }
            };
        }

        private static NestUpdate CreateNestUpdate(Nest nest)
        {
            return new NestUpdate
            {
                NestId = nest.Id,
                PokemonId = nest.PokemonId,
                MigrationNumber = nest.LastMigration,
                Timestamp = DateTime.UtcNow
            };
        }

        private static string GetNestTypeDescription(this NestType nestType)
        {
            return nestType switch
            {
                NestType.Cluster => "CLUSTER SPAWN",
                NestType.FrequentSpawnArea => "FREQUENT SPAWN AREA",
                NestType.FrequentSpawnPoint => "FREQUENT SPAWN POINT",
                NestType.Unknown => "UNKNOWN NEST TYPE",
                _ => string.Empty
            };
        }
    }
}