using Microsoft.EntityFrameworkCore;

namespace Database.Model
{
    public class FootballDbContext : DbContext
    {
        public FootballDbContext(DbContextOptions<FootballDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<PlayedMatch> PlayedMatches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Team Table
            modelBuilder.Entity<Team>().ToTable("tbl_Team")
                                       .HasKey(t => t.TeamId);
            modelBuilder.Entity<Team>().Property(t => t.TeamId)
                                       .ValueGeneratedOnAdd();
            modelBuilder.Entity<Team>().Property(t => t.TeamCode)
                                       .IsRequired()
                                       .HasMaxLength(3)
                                       .HasColumnType("varchar");
            modelBuilder.Entity<Team>().Property(t => t.TeamName)
                                       .IsRequired()
                                       .HasMaxLength(15)
                                       .HasColumnType("varchar");

            //Matches Played Table
            modelBuilder.Entity<PlayedMatch>().ToTable("tbl_MatchesPlayed")
                                              .HasKey(m => m.ID);
            modelBuilder.Entity<PlayedMatch>().Property(m => m.ID)
                                              .ValueGeneratedOnAdd();
            modelBuilder.Entity<PlayedMatch>().Property(m => m.MatchesPlayed)
                                              .HasColumnType("int");
            modelBuilder.Entity<PlayedMatch>().Property(m => m.Won)
                                              .HasColumnType("int");
            modelBuilder.Entity<PlayedMatch>().Property(m => m.Lost)
                                              .HasColumnType("int");
            modelBuilder.Entity<PlayedMatch>().Property(m => m.Draw)
                                              .HasColumnType("int");
            modelBuilder.Entity<PlayedMatch>().Property(m => m.Points)
                                              .HasColumnType("int");
            //modelBuilder.Entity<PlayedMatch>().HasOne<Team>()
            //                                  .WithMany()
            //                                  .HasForeignKey(p => p.TeamId);
            modelBuilder.Entity<PlayedMatch>().HasOne<Team>()
                                              .WithMany(p => p.PlayedMatches)
                                              .HasForeignKey(p => p.TeamId);
        }
    }
}
