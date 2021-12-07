using Mentor.Me.Data.Entities;
using Mentor.Me.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Mentor.Me.Data.Context
{
    public class MentorMeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Proposition> Propositions { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Assignment> Tasks { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<ApplyRequest> ApplyRequests { get; set; }

        public MentorMeContext(DbContextOptions<MentorMeContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.EnableSensitiveDataLogging();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PropositionConfiguration());
            modelBuilder.ApplyConfiguration(new ApplyRequestConfiguration());
            modelBuilder.ApplyConfiguration(new DealConfiguration());
            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
        }
    }
}
