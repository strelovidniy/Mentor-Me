using Mentor.Me.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mentor.Me.Data.EntityConfigurations
{
    internal class AssignmentConfiguration: IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder
                .ToTable("Assignments");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(e => e.Name)
                .IsRequired();
        }
    }
}
