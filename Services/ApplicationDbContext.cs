using System;
using System.Collections.Generic;
using BarberShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Services;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barber> Barbers { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barber>(entity =>
        {
            entity.HasKey(e => e.BarberId).HasName("PK__Barber__BE22A8AE73071EB0");

            entity.ToTable("Barber");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F24304B7523");

            entity.ToTable("Reservation");

            entity.Property(e => e.Comments)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Barber).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.BarberId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Reservati__Barbe__72C60C4A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
