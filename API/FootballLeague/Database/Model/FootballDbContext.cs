using Microsoft.EntityFrameworkCore;
using System;

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
            modelBuilder.Entity<Team>().HasData(
                            new Team
                            {
                                TeamId = 1,
                                TeamName = "Germany",
                                TeamCode = "Ger"
                            }, new Team
                            {
                                TeamId = 2,
                                TeamName = "Brazil",
                                TeamCode = "Bra"
                            }, new Team
                            {
                                TeamId = 3,
                                TeamName = "Sweden",
                                TeamCode = "Swe"
                            }, new Team
                            {
                                TeamId = 4,
                                TeamName = "Portugal",
                                TeamCode = "Por"
                            }, new Team
                            {
                                TeamId = 5,
                                TeamName = "India",
                                TeamCode = "Ind"
                            });
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
            modelBuilder.Entity<PlayedMatch>().HasData(
                            new PlayedMatch
                            {
                                ID = 1,
                                MatchesPlayed = 3,
                                Won = 1,
                                Lost = 1,
                                Draw = 0,
                                Points = 4,
                                TeamId = 3
                            });
        }
    }
}
