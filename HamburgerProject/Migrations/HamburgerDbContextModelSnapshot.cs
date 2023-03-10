// <auto-generated />
using System;
using HamburgerProject.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HamburgerProject.Migrations
{
    [DbContext(typeof(HamburgerDbContext))]
    partial class HamburgerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

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

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("HamburgerProject.Models.Entities.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("ExtraID")
                        .HasColumnType("int");

                    b.Property<int>("MenuID")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("ExtraID");

                    b.HasIndex("MenuID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("HamburgerProject.Models.Entities.Order", b =>
                {
                    b.HasOne("HamburgerProject.Models.Entities.Extra", "Extra")
                        .WithMany("Orders")
                        .HasForeignKey("ExtraID");

                    b.HasOne("HamburgerProject.Models.Entities.Menu", "Menu")
                        .WithMany("Orders")
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Extra");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("HamburgerProject.Models.Entities.Extra", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("HamburgerProject.Models.Entities.Menu", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
