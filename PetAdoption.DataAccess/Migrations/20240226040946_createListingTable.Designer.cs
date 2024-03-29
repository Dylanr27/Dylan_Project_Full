﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetAdoption.DataAccess.Data;

#nullable disable

namespace PetAdoption.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240226040946_createListingTable")]
    partial class createListingTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetAdoption.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Animal");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 7,
                            Breed = "Russian Blue",
                            Description = "Rescue",
                            Name = "Gizmo",
                            PhotoUrl = "/lib/Images/pexels-monica-oprea-9718154.jpg",
                            Sex = "Male",
                            Size = "M",
                            Species = "Cat"
                        });
                });

            modelBuilder.Entity("PetAdoption.Models.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("animalId")
                        .HasColumnType("int");

                    b.Property<int?>("productId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Listing");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 100.00m,
                            animalId = 1
                        });
                });

            modelBuilder.Entity("PetAdoption.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableQuantity = 50,
                            Brand = "Wild Coast",
                            Description = "Raw pork cat food. Freeze until ready to use. Good refrigerated for 3 days after inital thaw.",
                            PhotoUrl = "/lib/Images/wild-coast-raw-pork.png",
                            Type = "Cat Food"
                        },
                        new
                        {
                            Id = 2,
                            AvailableQuantity = 65,
                            Brand = "Wild Coast",
                            Description = "Raw chicken cat food. Freeze until ready to use. Good refrigerated for 3 days after inital thaw.",
                            PhotoUrl = "/lib/Images/wild-coast-raw-chicken.jpg",
                            Type = "Cat Food"
                        },
                        new
                        {
                            Id = 3,
                            AvailableQuantity = 45,
                            Brand = "Wild Coast",
                            Description = "Raw beef cat food. Freeze until ready to use. Good refrigerated for 3 days after inital thaw.",
                            PhotoUrl = "/lib/Images/wild-coast-raw-beef.jpg",
                            Type = "Cat Food"
                        },
                        new
                        {
                            Id = 4,
                            AvailableQuantity = 30,
                            Brand = "Wild Coast",
                            Description = "Raw turkey cat food. Freeze until ready to use. Good refrigerated for 3 days after inital thaw.",
                            PhotoUrl = "/lib/Images/wild-coast-raw-turkey.jpg",
                            Type = "Cat Food"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
