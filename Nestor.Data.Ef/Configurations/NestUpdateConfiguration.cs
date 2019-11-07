using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nestor.Data.Ef.Configurations
{
    internal class NestUpdateConfiguration : BaseEntityConfiguration<NestUpdate>
    {
        public override void Configure(EntityTypeBuilder<NestUpdate> builder)
        {
            base.Configure(builder);

            builder.HasOne(d => d.Pokemon)
                .WithMany(p => p.NestUpdates)
                .HasForeignKey(d => d.PokemonId);

            builder.HasOne(d => d.Nest)
                .WithMany(p => p.NestUpdates)
                .HasForeignKey(d => d.NestId);
        }
    }
}