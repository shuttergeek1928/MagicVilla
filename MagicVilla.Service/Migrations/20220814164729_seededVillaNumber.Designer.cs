﻿// <auto-generated />
using System;
using MagicVilla.Service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla.Service.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220814164729_seededVillaNumber")]
    partial class seededVillaNumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MagicVilla.Service.Models.Villa.VillaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Amenities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Villa");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a78dc47-c1cc-46a6-ab80-206e01c7a1e7"),
                            Amenities = "Pool, Gym, Bar",
                            Area = 750.00m,
                            CreatedDate = new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(4935),
                            Details = "Unmatched authentic luxury.",
                            ImageUrl = "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1",
                            LastUpdate = new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(4946),
                            Name = "Bliss View",
                            Occupancy = 5,
                            Rate = 500.00m
                        },
                        new
                        {
                            Id = new Guid("66cdf66c-c35b-4c98-95ae-767ccd307882"),
                            Amenities = "Pool, Gym, Bar",
                            Area = 1000.00m,
                            CreatedDate = new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(4950),
                            Details = "Moment Creating.",
                            ImageUrl = "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1",
                            LastUpdate = new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(4951),
                            Name = "Mountain View",
                            Occupancy = 3,
                            Rate = 1000.00m
                        });
                });

            modelBuilder.Entity("MagicVilla.Service.Models.VillaNumber.VillaNumberModel", b =>
                {
                    b.Property<int>("VillaNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VillaNumber");

                    b.ToTable("VillaNumber");

                    b.HasData(
                        new
                        {
                            VillaNumber = 1,
                            CreatedDate = new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(5078),
                            LastUpdated = new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(5079),
                            SpecialDetails = "Luxury."
                        });
                });
#pragma warning restore 612, 618
        }
    }
}