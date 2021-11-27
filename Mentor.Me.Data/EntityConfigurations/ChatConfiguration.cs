using Mentor.Me.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mentor.Me.Data.EntityConfigurations
{
    internal class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder
                .ToTable("Chats");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .IsRequired();

            builder
                .HasMany(e => e.Messages)
                .WithOne()
                .HasForeignKey(e => e.ChatId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
