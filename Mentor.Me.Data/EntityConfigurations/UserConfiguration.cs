using Mentor.Me.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mentor.Me.Data.EntityConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Users");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(e => e.Email)
                .IsRequired();

            builder
                .Property(e => e.FullName)
                .IsRequired();

            builder
                .HasMany(e => e.ApplyRequests)
                .WithOne()
                .HasForeignKey(e => e.OwnerId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(e => e.Propositions)
                .WithMany(e => e.Members);

            builder
                .HasMany(e => e.Deals)
                .WithMany(e => e.Members);

            builder
                .HasMany(e => e.Tasks)
                .WithMany(e => e.Members);
        }
    }
}
