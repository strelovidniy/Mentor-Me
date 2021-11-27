using Mentor.Me.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mentor.Me.Data.EntityConfigurations
{
    internal class ApplyRequestConfiguration: IEntityTypeConfiguration<ApplyRequest>
    {
        public void Configure(EntityTypeBuilder<ApplyRequest> builder)
        {
            builder
                .ToTable("ApplyRequests");

            builder
                .HasKey(x => x.Id);
        }
    }
}
