﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetAdoptionMVC.Data;

#nullable disable

namespace PetAdoptionMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240123193658_PhotoUrlFieldAddedToAnimalTable")]
    partial class PhotoUrlFieldAddedToAnimalTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetAdoptionMVC.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdoptionStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
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
                            AdoptionStatus = "Available",
                            Age = 7,
                            Breed = "Russian Blue",
                            Description = "Rescue",
                            Gender = "Boy",
                            Name = "Gizmo",
                            PhotoUrl = "\"C:\\Renton-Technical-College\\Winter-2024\\CSI-340\\pexels-nothing-ahead-17987994 (1).jpg\"",
                            Size = "M",
                            Species = "Cat"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
