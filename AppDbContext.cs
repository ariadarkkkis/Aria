using System;
using System.IO;
using System.Runtime.InteropServices;
using Aria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace Aria.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(string constr) 
            : base(new DbContextOptionsBuilder<AppDbContext>().UseMySql(constr).Options)
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>()
                .HasKey(mc => new { mc.MovieId, mc.CategoryId });

            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCategories)
                .HasForeignKey(mc => mc.MovieId);
            
            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.Category)
                .WithMany(c => c.MovieCategories)
                .HasForeignKey(mc => mc.CategoryId);
            
            modelBuilder.Entity<Movie>()
                .Property(w => w.Name)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(q => q.Name)
                .HasMaxLength(255)
                .IsRequired();
        }

    }
}