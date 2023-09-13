using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FMS_Backend;

public partial class FuelManagementSystemContext : DbContext
{
    public FuelManagementSystemContext()
    {
    }

    public FuelManagementSystemContext(DbContextOptions<FuelManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FuelInventory> FuelInventories { get; set; }

    public virtual DbSet<FuelLocation> FuelLocations { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TripDetail> TripDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("host=localhost;database=FuelManagementSystem;username=postgres;password=aA1234567890");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FuelInventory>(entity =>
        {
            entity.HasKey(e => e.Fuelid).HasName("fuel_inventory_pkey");

            entity.ToTable("fuel_inventory");

            entity.Property(e => e.Fuelid)
                .ValueGeneratedNever()
                .HasColumnName("fuelid");
            entity.Property(e => e.Fueldensity).HasColumnName("fueldensity");
            entity.Property(e => e.Fuelprice).HasColumnName("fuelprice");
            entity.Property(e => e.Fuelqty).HasColumnName("fuelqty");
            entity.Property(e => e.Fueltype)
                .HasMaxLength(60)
                .HasColumnName("fueltype");
            entity.Property(e => e.Locid)
                .HasMaxLength(60)
                .HasColumnName("locid");
        });

        modelBuilder.Entity<FuelLocation>(entity =>
        {
            entity.HasKey(e => e.Locid).HasName("fuel_location_pkey");

            entity.ToTable("fuel_location");

            entity.Property(e => e.Locid)
                .ValueGeneratedNever()
                .HasColumnName("locid");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.Geocode).HasColumnName("geocode");
            entity.Property(e => e.Locname)
                .HasMaxLength(60)
                .HasColumnName("locname");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Transactionid).HasName("transactions_pkey");

            entity.ToTable("transactions");

            entity.Property(e => e.Transactionid)
                .ValueGeneratedNever()
                .HasColumnName("transactionid");
            entity.Property(e => e.Fuelcost).HasColumnName("fuelcost");
            entity.Property(e => e.Fuelingdate).HasColumnName("fuelingdate");
            entity.Property(e => e.Fuelinglocid).HasColumnName("fuelinglocid");
            entity.Property(e => e.Paymentmethod)
                .HasMaxLength(60)
                .HasColumnName("paymentmethod");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Vehicleid).HasColumnName("vehicleid");
        });

        modelBuilder.Entity<TripDetail>(entity =>
        {
            entity.HasKey(e => e.Tripid).HasName("trip_details_pkey");

            entity.ToTable("trip_details");

            entity.Property(e => e.Tripid)
                .ValueGeneratedNever()
                .HasColumnName("tripid");
            entity.Property(e => e.Fuelend).HasColumnName("fuelend");
            entity.Property(e => e.Fuelstart).HasColumnName("fuelstart");
            entity.Property(e => e.Odometerend).HasColumnName("odometerend");
            entity.Property(e => e.Odometerstart).HasColumnName("odometerstart");
            entity.Property(e => e.Tripdatetime).HasColumnName("tripdatetime");
            entity.Property(e => e.Tripmileage).HasColumnName("tripmileage");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Vehicleid).HasColumnName("vehicleid");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.Userid)
                .ValueGeneratedNever()
                .HasColumnName("userid");
            entity.Property(e => e.Contact)
                .HasMaxLength(60)
                .HasColumnName("contact");
            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(60)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Vehicleid).HasName("vehicle_pkey");

            entity.ToTable("vehicle");

            entity.Property(e => e.Vehicleid)
                .ValueGeneratedNever()
                .HasColumnName("vehicleid");
            entity.Property(e => e.Fuelefficiency)
                .HasMaxLength(20)
                .HasColumnName("fuelefficiency");
            entity.Property(e => e.Fueltype)
                .HasMaxLength(60)
                .HasColumnName("fueltype");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Vehicletype)
                .HasMaxLength(60)
                .HasColumnName("vehicletype");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
