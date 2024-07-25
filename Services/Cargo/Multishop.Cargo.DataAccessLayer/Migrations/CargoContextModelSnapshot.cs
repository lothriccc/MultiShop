﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Multishop.Cargo.DataAccessLayer.Concrete;

#nullable disable

namespace Multishop.Cargo.DataAccessLayer.Migrations
{
    [DbContext(typeof(CargoContext))]
    partial class CargoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MultiShop.Cargo.EntityLayer.Concrete.CargoCompany", b =>
                {
                    b.Property<int>("CargoCompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoCompanyID"), 1L, 1);

                    b.Property<string>("CargoCompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoCompanyID");

                    b.ToTable("cargoCompanies");
                });

            modelBuilder.Entity("MultiShop.Cargo.EntityLayer.Concrete.CargoCustomer", b =>
                {
                    b.Property<int>("CargoCustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoCustomerID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoCustomerID");

                    b.ToTable("CargoCustomers");
                });

            modelBuilder.Entity("MultiShop.Cargo.EntityLayer.Concrete.CargoDetail", b =>
                {
                    b.Property<int>("CargoDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoDetailID"), 1L, 1);

                    b.Property<int>("Barcode")
                        .HasColumnType("int");

                    b.Property<int>("CargoCompanyID")
                        .HasColumnType("int");

                    b.Property<string>("ReceiverCustomer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderCustomer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoDetailID");

                    b.HasIndex("CargoCompanyID");

                    b.ToTable("CargoDetails");
                });

            modelBuilder.Entity("MultiShop.Cargo.EntityLayer.Concrete.CargoOperation", b =>
                {
                    b.Property<int>("CargoOperationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoOperationID"), 1L, 1);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CargoOperationID");

                    b.ToTable("CargoOperations");
                });

            modelBuilder.Entity("MultiShop.Cargo.EntityLayer.Concrete.CargoDetail", b =>
                {
                    b.HasOne("MultiShop.Cargo.EntityLayer.Concrete.CargoCompany", "CargoCompany")
                        .WithMany()
                        .HasForeignKey("CargoCompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CargoCompany");
                });
#pragma warning restore 612, 618
        }
    }
}
