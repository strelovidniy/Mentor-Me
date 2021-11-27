using Mentor.Me.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mentor.Me.Data.EntityConfigurations
{
    internal class DealConfiguration: IEntityTypeConfiguration<Deal>
    {
        public void Configure(EntityTypeBuilder<Deal> builder)
        {
            builder
                .ToTable("Deals");

            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(e => e.Chat)
                .WithOne()
                .HasPrincipalKey<Deal>(e => e.Id)
                .HasForeignKey<Chat>(e => e.DealId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
