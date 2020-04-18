using System;
using AdoptADrain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace AdoptADrain.Services
{
    public partial class AdoptADrainDataContext : DbContext
    {
        public static readonly IConfiguration configuration;
        public AdoptADrainDataContext()
        {
        }

        public AdoptADrainDataContext(DbContextOptions<AdoptADrainDataContext> options)
            : base(options)
        {
        }

        //Domain Model Classes
        public virtual DbSet<StormDrain> StormDrain{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(configuration["DefaultConnection"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StormDrain>(entity =>
            {
                entity.ToTable("StormDrain", "Drain");

                entity.Property(e => e.StormDrainId).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
