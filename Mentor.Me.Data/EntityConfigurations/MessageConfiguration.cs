using Mentor.Me.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mentor.Me.Data.EntityConfigurations
{
    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .ToTable("Messages");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(e => e.Text)
                .IsRequired();

            builder
                .Property(e => e.Date)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()");

            builder
                .HasOne(e => e.Sender)
                .WithMany()
                .HasForeignKey(e => e.SenderId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
