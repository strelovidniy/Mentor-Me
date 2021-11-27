using Microsoft.EntityFrameworkCore;

namespace Mentor.Me.Data.Context
{
    public class MentorMeContext : DbContext
    {
        public MentorMeContext(DbContextOptions<MentorMeContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.EnableSensitiveDataLogging();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
