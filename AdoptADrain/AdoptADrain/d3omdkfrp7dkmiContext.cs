using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace AdoptADrain
{
    public partial class d3omdkfrp7dkmiContext : DbContext
    {
        public static readonly IConfiguration configuration;
        public d3omdkfrp7dkmiContext()
        {
        }

        public d3omdkfrp7dkmiContext(DbContextOptions<d3omdkfrp7dkmiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StormDrain> StormDrain { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(configuration["DefaultConnection"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StormDrain>(entity =>
            {
                entity.ToTable("StormDrain", "Drain");

                entity.Property(e => e.StormDrainId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
