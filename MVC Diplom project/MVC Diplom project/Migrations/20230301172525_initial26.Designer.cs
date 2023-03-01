﻿// <auto-generated />
using System;
using MVC_Diplom_project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVC_Diplom_project.Migrations
{
    [DbContext(typeof(CarPortalDBContext))]
    [Migration("20230301172525_initial26")]
    partial class initial26
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVC_Diplom_project.Data.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Fuel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("СarBrand")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("MVC_Diplom_project.Data.Models.Logbook", b =>
                {
                    b.Property<Guid>("LogbookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId2")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameLog")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LogbookId");

                    b.HasIndex("CarId");

                    b.HasIndex("CarId1");

                    b.ToTable("Logbooks");
                });

            modelBuilder.Entity("MVC_Diplom_project.Data.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MVC_Diplom_project.Data.Models.Car", b =>
                {
                    b.HasOne("MVC_Diplom_project.Data.Models.User", null)
                        .WithMany("CarsList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVC_Diplom_project.Data.Models.Logbook", b =>
                {
                    b.HasOne("MVC_Diplom_project.Data.Models.Car", null)
                        .WithMany("LogbooksList")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_Diplom_project.Data.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId1");
                });
#pragma warning restore 612, 618
        }
    }
}
