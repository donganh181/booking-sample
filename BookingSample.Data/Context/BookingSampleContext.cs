using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BookingSample.Data.Models;

#nullable disable

namespace BookingSample.Data.Context
{
    public partial class BookingSampleContext : DbContext
    {
        public BookingSampleContext()
        {
        }

        public BookingSampleContext(DbContextOptions<BookingSampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderBooking> OrderBookings { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=45.119.212.77, 9943;Database=BookingSample;User Id =sa;Password=Goboi123;Trusted_Connection=False;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<OrderBooking>(entity =>
            {
                entity.ToTable("OrderBooking");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.OnDate)
                    .HasColumnType("date")
                    .HasColumnName("onDate");

                entity.Property(e => e.OnTime).HasColumnName("onTime");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.OrderBookings)
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK__OrderBook__Route__2C3393D0");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.OrderBookings)
                    .HasForeignKey(d => d.SeatId)
                    .HasConstraintName("FK__OrderBook__SeatI__2B3F6F97");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("Route");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FromPlace).HasMaxLength(50);

                entity.Property(e => e.ToPlace).HasMaxLength(50);
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("Seat");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
