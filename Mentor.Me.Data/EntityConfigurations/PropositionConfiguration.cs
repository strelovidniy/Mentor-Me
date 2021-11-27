using Mentor.Me.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mentor.Me.Data.EntityConfigurations
{
    internal class PropositionConfiguration : IEntityTypeConfiguration<Proposition>
    {
        public void Configure(EntityTypeBuilder<Proposition> builder)
        {
            builder
                .ToTable("Propositions");

            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(e => e.Skills)
                .WithOne()
                .HasForeignKey(e => e.PropositionId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}
