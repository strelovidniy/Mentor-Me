using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Mentor.Me.Data.Entities.Task;

namespace Mentor.Me.Data.EntityConfigurations
{
    internal class TaskConfiguration: IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .ToTable("Tasks");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(e => e.Name)
                .IsRequired();
        }
    }
}
