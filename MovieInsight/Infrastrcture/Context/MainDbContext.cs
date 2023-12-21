using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Directors> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Movie_Genres> MovieGenres { get; set; }
        public DbSet<Movie_Direction> MovieDirection { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Movie_Cast> MovieCast { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, indexes, and other constraints here

            modelBuilder.Entity<Movie_Genres>()
                .HasKey(mg => new { mg.MovId, mg.GenId });

            modelBuilder.Entity<Movie_Direction>()
                .HasKey(md => new { md.DirId, md.MovId });

            modelBuilder.Entity<Rating>()
                .HasKey(r => new { r.MovId, r.RevId });

            modelBuilder.Entity<Movie_Cast>()
                .HasKey(mc => new { mc.ActId, mc.MovId });

            modelBuilder.Entity<Movie_Genres>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.Genres)
                .HasForeignKey(mg => mg.MovId);

            modelBuilder.Entity<Movie_Genres>()
                .HasOne(mg => mg.Genres)
                .WithMany(g => g.Movies)
                .HasForeignKey(mg => mg.GenId);

            modelBuilder.Entity<Movie_Direction>()
                .HasOne(md => md.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(md => md.DirId);

            modelBuilder.Entity<Movie_Direction>()
                .HasOne(md => md.Movie)
                .WithMany(m => m.Directors)
                .HasForeignKey(md => md.MovId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Ratings)
                .HasForeignKey(r => r.MovId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Reviewer)
                .WithMany(rev => rev.Ratings)
                .HasForeignKey(r => r.RevId);

            modelBuilder.Entity<Movie_Cast>()
                .HasOne(mc => mc.Actor)
                .WithMany(act => act.Movies)
                .HasForeignKey(mc => mc.ActId);

            modelBuilder.Entity<Movie_Cast>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.Cast)
                .HasForeignKey(mc => mc.MovId);
        }
    }
}
