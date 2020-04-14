using BasketballWorldCup.Model;
using Microsoft.EntityFrameworkCore;

namespace BasketballWorldCup.Database
{
    public class BasketballContext : DbContext
    {
        public DbSet<Draw> Draws { get; set; }

        public DbSet<Pot> Pots { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Team> Teams { get; set; }

        public BasketballContext(DbContextOptions<BasketballContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Draw>()
                .HasMany(d => d.Pots)
                .WithOne(p => p.Draw);

            modelBuilder.Entity<TeamPot>()
                .HasKey(tp => new { tp.TeamId, tp.PotId });
            modelBuilder.Entity<TeamPot>()
                .HasOne(tp => tp.Pot)
                .WithMany(p => p.TeamPots)
                .HasForeignKey(tp => tp.PotId);
            modelBuilder.Entity<TeamPot>()
                .HasOne(tp => tp.Team)
                .WithMany(t => t.TeamPots)
                .HasForeignKey(tp => tp.TeamId);

            modelBuilder.Entity<TeamGroup>()
                .HasKey(tg => new { tg.TeamId, tg.GroupId });
            modelBuilder.Entity<TeamGroup>()
                .HasOne(tg => tg.Group)
                .WithMany(g => g.TeamGroups)
                .HasForeignKey(tg => tg.GroupId);
            modelBuilder.Entity<TeamGroup>()
                .HasOne(tg => tg.Team)
                .WithMany(t => t.TeamGroups)
                .HasForeignKey(tg => tg.TeamId);
        }
    }
}
