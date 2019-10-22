using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nestor.Data.Ef.Configurations
{
    internal class NestConfiguration : BaseEntityConfiguration<Nest>
    {
        public override void Configure(EntityTypeBuilder<Nest> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.HasOne(d => d.Pokemon)
                .WithMany(p => p.Nests)
                .HasForeignKey(d => d.PokemonId);
        }
    }
}