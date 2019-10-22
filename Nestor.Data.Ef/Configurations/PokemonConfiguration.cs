using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nestor.Data.Ef.Configurations
{
    internal class PokemonConfiguration : BaseEntityConfiguration<Pokemon>
    {
        public override void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Id)
                .ValueGeneratedNever();
        }
    }
}