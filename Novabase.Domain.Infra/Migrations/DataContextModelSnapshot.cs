﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Novabase.Domain.Infra.Contexts;

namespace Novabase.Domain.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Novabase.Domain.Entities.Checkpoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPackage")
                        .HasColumnType("int");

                    b.Property<int>("IdPlaceType")
                        .HasColumnType("int");

                    b.Property<int>("IdStatus")
                        .HasColumnType("int");

                    b.Property<int>("IdTypeControl")
                        .HasColumnType("int");

                    b.Property<DateTime>("InteractionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdPackage");

                    b.HasIndex("IdPlaceType");

                    b.HasIndex("IdStatus");

                    b.HasIndex("IdTypeControl");

                    b.ToTable("Checkpoints");
                });

            modelBuilder.Entity("Novabase.Domain.Entities.CountryCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cctld")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsoAlpha2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsoAlpha3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumericCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CountryCodes");
                });

            modelBuilder.Entity("Novabase.Domain.Entities.Indicator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdIndicatorType")
                        .HasColumnType("int");

                    b.Property<string>("Initial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdIndicatorType");

                    b.ToTable("Indicators");
                });

            modelBuilder.Entity("Novabase.Domain.Entities.IndicatorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Initials")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IndicatorTypes");
                });

            modelBuilder.Entity("Novabase.Domain.Entities.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodeArea")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasValueToPay")
                        .HasColumnType("bit");

                    b.Property<int>("IdSize")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReceiveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrackingCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdSize");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("Novabase.Domain.Entities.Checkpoint", b =>
                {
                    b.HasOne("Novabase.Domain.Entities.Package", "Package")
                        .WithMany("Checkpoints")
                        .HasForeignKey("IdPackage")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Novabase.Domain.Entities.Indicator", "Placetype")
                        .WithMany()
                        .HasForeignKey("IdPlaceType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Novabase.Domain.Entities.Indicator", "Status")
                        .WithMany()
                        .HasForeignKey("IdStatus")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Novabase.Domain.Entities.Indicator", "TypeControl")
                        .WithMany()
                        .HasForeignKey("IdTypeControl")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Novabase.Domain.Entities.Indicator", b =>
                {
                    b.HasOne("Novabase.Domain.Entities.IndicatorType", "IndicatorType")
                        .WithMany()
                        .HasForeignKey("IdIndicatorType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Novabase.Domain.Entities.Package", b =>
                {
                    b.HasOne("Novabase.Domain.Entities.Indicator", "Size")
                        .WithMany()
                        .HasForeignKey("IdSize")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
