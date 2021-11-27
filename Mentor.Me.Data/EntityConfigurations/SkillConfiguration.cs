using Mentor.Me.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mentor.Me.Data.EntityConfigurations
{
    internal class SkillConfiguration: IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder
                .ToTable("Skills");

            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(e => e.Tasks)
                .WithOne()
                .HasForeignKey(e => e.SkillId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
