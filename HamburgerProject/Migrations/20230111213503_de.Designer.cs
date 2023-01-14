﻿// <auto-generated />
using System;
using HamburgerProject.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HamburgerProject.Migrations
{
    [DbContext(typeof(HamburgerDbContext))]
    [Migration("20230111213503_de")]
    partial class de
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HamburgerProject.Models.Entities.Extra", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("OrderID")
                        .IsUnique()
                        .HasFilter("[OrderID] IS NOT NULL");

                    b.ToTable("Extras");
                });

            modelBuilder.Entity("HamburgerProject.Models.Entities.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("OrderID")
                        .IsUnique()
                        .HasFilter("[OrderID] IS NOT NULL");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("HamburgerProject.Models.Entities.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("HamburgerProject.Models.Entities.Extra", b =>
                {
                    b.HasOne("HamburgerProject.Models.Entities.Order", "Order")
                        .WithOne("Extra")
                        .HasForeignKey("HamburgerProject.Models.Entities.Extra", "OrderID");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("HamburgerProject.Models.Entities.Menu", b =>
                {
                    b.HasOne("HamburgerProject.Models.Entities.Order", "Order")
                        .WithOne("Menu")
                        .HasForeignKey("HamburgerProject.Models.Entities.Menu", "OrderID");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("HamburgerProject.Models.Entities.Order", b =>
                {
                    b.Navigation("Extra")
                        .IsRequired();

                    b.Navigation("Menu")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
