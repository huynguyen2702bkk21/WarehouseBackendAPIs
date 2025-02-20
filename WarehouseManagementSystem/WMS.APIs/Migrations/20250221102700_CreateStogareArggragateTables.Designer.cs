﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WMS.Infrastructure;

#nullable disable

namespace WMS.APIs.Migrations
{
    [DbContext(typeof(WMSDbContext))]
    [Migration("20250221102700_CreateStogareArggragateTables")]
    partial class CreateStogareArggragateTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialSubLot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("existingQuality")
                        .HasColumnType("double precision");

                    b.Property<string>("locationId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("lotNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("subLotId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("subLotStatus")
                        .HasColumnType("integer");

                    b.Property<int>("unitOfMeasure")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("locationId");

                    b.ToTable("MaterialSubLot");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.PersonAggregate.Customer", b =>
                {
                    b.Property<string>("customerId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("contactDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("customerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("customerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.PersonAggregate.Employee", b =>
                {
                    b.Property<string>("employeeId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("employeeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("employeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.PersonAggregate.Supplier", b =>
                {
                    b.Property<string>("supplierId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("contactDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("supplierName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("supplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.StorageAggregate.Location", b =>
                {
                    b.Property<string>("locationId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("warehouseId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("locationId");

                    b.HasIndex("warehouseId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.StorageAggregate.Warehouse", b =>
                {
                    b.Property<string>("warehouseId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("warehouseName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("warehouseId");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialSubLot", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.StorageAggregate.Location", "location")
                        .WithMany("materialSubLots")
                        .HasForeignKey("locationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("location");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.StorageAggregate.Location", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.StorageAggregate.Warehouse", "warehouse")
                        .WithMany("locations")
                        .HasForeignKey("warehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("warehouse");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.StorageAggregate.Location", b =>
                {
                    b.Navigation("materialSubLots");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.StorageAggregate.Warehouse", b =>
                {
                    b.Navigation("locations");
                });
#pragma warning restore 612, 618
        }
    }
}
