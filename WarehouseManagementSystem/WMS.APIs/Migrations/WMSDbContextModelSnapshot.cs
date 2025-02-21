﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WMS.Infrastructure;

#nullable disable

namespace WMS.APIs.Migrations
{
    [DbContext(typeof(WMSDbContext))]
    partial class WMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WMS.Domain.AggregateModels.EquipmentAggregate.Equipment", b =>
                {
                    b.Property<string>("equipmentId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("equipmentClassId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("equipmentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("equipmentId");

                    b.HasIndex("equipmentClassId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.EquipmentAggregate.EquipmentClass", b =>
                {
                    b.Property<string>("equipmentClassId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("className")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("equipmentClassId");

                    b.ToTable("EquipmentClasses");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.EquipmentAggregate.EquipmentClassProperty", b =>
                {
                    b.Property<string>("propertyId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("equipmentClassId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("propertyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("propertyValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("unitOfMeasure")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("propertyId");

                    b.HasIndex("equipmentClassId");

                    b.ToTable("EquipmentClassProperties");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.EquipmentAggregate.EquipmentProperty", b =>
                {
                    b.Property<string>("propertyId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("equipmentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("propertyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("propertyValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("unitOfMeasure")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("propertyId");

                    b.HasIndex("equipmentId");

                    b.ToTable("EquipmentProperties");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.Material", b =>
                {
                    b.Property<string>("materialId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("materialClassId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("materialName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("materialId");

                    b.HasIndex("materialClassId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialClass", b =>
                {
                    b.Property<string>("materialClassId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("className")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("materialClassId");

                    b.ToTable("MaterialClasses");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialClassProperty", b =>
                {
                    b.Property<string>("propertyId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("materialClassId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("propertyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("propertyValue")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("unitOfMeasure")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("propertyId");

                    b.HasIndex("materialClassId");

                    b.ToTable("MaterialClassProperties");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialLot", b =>
                {
                    b.Property<string>("lotNumber")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<double>("exisitingQuantity")
                        .HasColumnType("double precision");

                    b.Property<string>("lotStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("materialId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("lotNumber");

                    b.HasIndex("materialId");

                    b.ToTable("MaterialLots");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialLotProperty", b =>
                {
                    b.Property<string>("propertyId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("lotNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("propertyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("propertyValue")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("unitOfMeasure")
                        .HasColumnType("integer");

                    b.HasKey("propertyId");

                    b.HasIndex("lotNumber");

                    b.ToTable("MaterialLotProperties");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialProperty", b =>
                {
                    b.Property<string>("propertyId")
                        .HasColumnType("text");

                    b.Property<string>("materialId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("propertyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("propertyValue")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("unitOfMeasure")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("propertyId");

                    b.HasIndex("materialId");

                    b.ToTable("MaterialProperties");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialSubLot", b =>
                {
                    b.Property<string>("subLotId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<double>("existingQuality")
                        .HasColumnType("double precision");

                    b.Property<string>("locationId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("lotNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("subLotStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("unitOfMeasure")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("subLotId");

                    b.HasIndex("locationId");

                    b.HasIndex("lotNumber");

                    b.ToTable("MaterialSubLots");
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

            modelBuilder.Entity("WMS.Domain.AggregateModels.EquipmentAggregate.Equipment", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.EquipmentAggregate.EquipmentClass", "equipmentClass")
                        .WithMany("equipments")
                        .HasForeignKey("equipmentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("equipmentClass");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.EquipmentAggregate.EquipmentClassProperty", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.EquipmentAggregate.EquipmentClass", "equipmentClass")
                        .WithMany("properties")
                        .HasForeignKey("equipmentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("equipmentClass");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.EquipmentAggregate.EquipmentProperty", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.EquipmentAggregate.Equipment", "equipment")
                        .WithMany("properties")
                        .HasForeignKey("equipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("equipment");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.Material", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.MaterialAggregate.MaterialClass", "materialClass")
                        .WithMany("materials")
                        .HasForeignKey("materialClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("materialClass");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialClassProperty", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.MaterialAggregate.MaterialClass", "materialClass")
                        .WithMany("properties")
                        .HasForeignKey("materialClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("materialClass");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialLot", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.MaterialAggregate.Material", "material")
                        .WithMany("lots")
                        .HasForeignKey("materialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("material");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialLotProperty", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.MaterialAggregate.MaterialLot", "materialLot")
                        .WithMany("properties")
                        .HasForeignKey("lotNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("materialLot");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialProperty", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.MaterialAggregate.Material", "material")
                        .WithMany("porperties")
                        .HasForeignKey("materialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("material");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialSubLot", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.StorageAggregate.Location", "location")
                        .WithMany("materialSubLots")
                        .HasForeignKey("locationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMS.Domain.AggregateModels.MaterialAggregate.MaterialLot", "materialLot")
                        .WithMany("subLots")
                        .HasForeignKey("lotNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("location");

                    b.Navigation("materialLot");
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

            modelBuilder.Entity("WMS.Domain.AggregateModels.EquipmentAggregate.Equipment", b =>
                {
                    b.Navigation("properties");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.EquipmentAggregate.EquipmentClass", b =>
                {
                    b.Navigation("equipments");

                    b.Navigation("properties");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.Material", b =>
                {
                    b.Navigation("lots");

                    b.Navigation("porperties");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialClass", b =>
                {
                    b.Navigation("materials");

                    b.Navigation("properties");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.MaterialAggregate.MaterialLot", b =>
                {
                    b.Navigation("properties");

                    b.Navigation("subLots");
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
