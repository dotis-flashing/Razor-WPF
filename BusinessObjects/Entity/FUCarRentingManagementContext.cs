﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Entity
{
    public partial class FUCarRentingManagementContext : DbContext
    {
        public FUCarRentingManagementContext()
        {
        }

        public FUCarRentingManagementContext(DbContextOptions<FUCarRentingManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarInformation> CarInformations { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<RentingDetail> RentingDetails { get; set; } = null!;
        public virtual DbSet<RentingTransaction> RentingTransactions { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-ULDR55OI\\MSSQLSERVER01;Database=FUCarRentingManagement;User ID=sa;Password=12345;TrustServerCertificate=True;MultipleActiveResultSets=true");  }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectString:DatabaseConnection"];

            return strConn;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarInformation>(entity =>
            {
                entity.HasKey(e => e.CarId);

                entity.ToTable("CarInformation");

                entity.Property(e => e.CarId).HasColumnName("CarID").ValueGeneratedOnAdd();

                entity.Property(e => e.CarDescription).HasMaxLength(220);

                entity.Property(e => e.CarName).HasMaxLength(50);

                entity.Property(e => e.CarRentingPricePerDay).HasColumnType("money");

                entity.Property(e => e.FuelType).HasMaxLength(20);
                entity.Property(e => e.CarStatus).HasMaxLength(255);

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.CarInformations)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_CarInformation_Manufacturer");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.CarInformations)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_CarInformation_Supplier");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.Email, "UQ__Customer__A9D1053455277C1A")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID").ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerBirthday).HasColumnType("date");

                entity.Property(e => e.CustomerName).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
                entity.Property(e => e.CustomerStatus).HasMaxLength(255);

                entity.Property(e => e.Telephone).HasMaxLength(12);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID").ValueGeneratedOnAdd();

                entity.Property(e => e.Description).HasMaxLength(250);
                entity.Property(e => e.ManufacturerStatus).HasMaxLength(255);

                entity.Property(e => e.ManufacturerCountry)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ManufacturerName).HasMaxLength(50);
            });

            modelBuilder.Entity<RentingDetail>(entity =>
            {
                entity.HasKey(e => new { e.RentingTransactionId, e.CarId });

                entity.ToTable("RentingDetail");

                entity.Property(e => e.RentingTransactionId).HasColumnName("RentingTransactionID").ValueGeneratedOnAdd();

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.EndDate).HasColumnType("date");
                entity.Property(e => e.RentingDetailStatus).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.RentingDetails)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_RentingDetail_CarInformation");

                entity.HasOne(d => d.RentingTransaction)
                    .WithMany(p => p.RentingDetails)
                    .HasForeignKey(d => d.RentingTransactionId)
                    .HasConstraintName("FK_RentingDetail_RentingTransaction");
            });

            modelBuilder.Entity<RentingTransaction>(entity =>
            {
                entity.HasKey(e => e.RentingTransationId);

                entity.ToTable("RentingTransaction");

                entity.Property(e => e.RentingTransationId).ValueGeneratedOnAdd()
                    .HasColumnName("RentingTransationID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
                entity.Property(e => e.RentingStatus).HasMaxLength(255);

                entity.Property(e => e.RentingDate).HasColumnType("date");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RentingTransactions)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_RentingTransaction_Customer");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.SupplierAddress).HasMaxLength(80);
                entity.Property(e => e.SupplierStatus).HasMaxLength(255);
                entity.Property(e => e.SupplierDescription).HasMaxLength(250);

                entity.Property(e => e.SupplierName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }



        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}