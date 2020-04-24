using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace AdoptADrain.DomainModels
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

        public virtual DbSet<Drain> Drain { get; set; }
        public virtual DbSet<DrainStatus> DrainStatus { get; set; }
        public virtual DbSet<DrainStatusHistory> DrainStatusHistory { get; set; }
        public virtual DbSet<DrainType> DrainType { get; set; }
        public virtual DbSet<FlowDirection> FlowDirection { get; set; }
        public virtual DbSet<RoadType> RoadType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(configuration["DefaultConnection"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drain>(entity =>
            {
                entity.ToTable("Drain", "Drain");

                entity.Property(e => e.DrainId).HasDefaultValueSql("nextval('\"Drain\".\"StormDrain_StormDrainId_seq\"'::regclass)");

                entity.Property(e => e.ChangeDttm).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreateDttm).HasColumnType("timestamp with time zone");

                entity.Property(e => e.DrainId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.DrainType)
                    .WithMany(p => p.Drain)
                    .HasForeignKey(d => d.DrainTypeId)
                    .HasConstraintName("DrainType_fkey");

                entity.HasOne(d => d.FlowDirection)
                    .WithMany(p => p.Drain)
                    .HasForeignKey(d => d.FlowDirectionId)
                    .HasConstraintName("FlowDirection_fkey");

                entity.HasOne(d => d.RoadType)
                    .WithMany(p => p.Drain)
                    .HasForeignKey(d => d.RoadTypeId)
                    .HasConstraintName("RoadType_fkey");
            });

            modelBuilder.Entity<DrainStatusHistory>(entity =>
            {
                entity.ToTable("DrainStatusHistory", "Drain");

                entity.Property(e => e.StatusCreateDttm).HasColumnType("date");

                entity.HasOne(d => d.Drain)
                    .WithMany(p => p.DrainStatusHistory)
                    .HasForeignKey(d => d.DrainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Drain_fkey");

                entity.HasOne(d => d.DrainStatus)
                    .WithMany(p => p.DrainStatusHistory)
                    .HasForeignKey(d => d.DrainStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DrainStatus_fkey");
            });

            modelBuilder.Entity<DrainStatus>(entity =>
            {
                entity.ToTable("DrainStatus", "Drain");
                //entity.Property(e => e.DrainStatusId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DrainType>(entity =>
            {
                entity.ToTable("DrainType", "Drain");
                //entity.Property(e => e.DrainTypeId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<FlowDirection>(entity =>
            {
                entity.ToTable("FlowDirection", "Drain");
                //entity.Property(e => e.FlowDirectionId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<RoadType>(entity =>
            {
                entity.ToTable("RoadType", "Drain");
                //entity.Property(e => e.RoadTypeId).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
