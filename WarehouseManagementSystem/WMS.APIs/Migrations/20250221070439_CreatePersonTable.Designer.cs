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
    [Migration("20250221070439_CreatePersonTable")]
    partial class CreatePersonTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WMS.Domain.AggregateModels.PersonAggregate.Employee", b =>
                {
                    b.Property<string>("personId")
                        .HasColumnType("text");

                    b.Property<string>("personName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("role")
                        .HasColumnType("integer");

                    b.HasKey("personId");

                    b.ToTable("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
