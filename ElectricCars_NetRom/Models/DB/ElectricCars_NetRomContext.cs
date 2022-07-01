using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ElectricCars_NetRom.Models.DB
{
    public partial class ElectricCars_NetRomContext : DbContext
    {
        public ElectricCars_NetRomContext()
        {
        }

        public ElectricCars_NetRomContext(DbContextOptions<ElectricCars_NetRomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Plug> Plugs { get; set; } = null!;
        public virtual DbSet<PlugType> PlugTypes { get; set; } = null!;
        public virtual DbSet<Station> Stations { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CarNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.PlugId).HasColumnName("PlugID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Plug)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PlugId)
                    .HasConstraintName("FK_Booking_Plug");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Booking_Users");
            });

            modelBuilder.Entity<Plug>(entity =>
            {
                entity.ToTable("Plug");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StationId).HasColumnName("StationID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Plugs)
                    .HasForeignKey(d => d.StationId)
                    .HasConstraintName("FK_Plug_Station");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Plugs)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Plug_PlugTypes1");
            });

            modelBuilder.Entity<PlugType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("Station");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adress).HasMaxLength(150);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.UserEmail).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(150);

                entity.Property(e => e.UserPassword).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
