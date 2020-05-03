﻿// <auto-generated />
using BankZdjecOlsztyn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankZdjecOlsztyn.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200502190851_TagMiejsce")]
    partial class TagMiejsce
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankZdjecOlsztyn.Models.Miejsce", b =>
                {
                    b.Property<int>("MiejsceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(188)")
                        .HasMaxLength(188);

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(588)")
                        .HasMaxLength(588);

                    b.Property<double>("szerokosc")
                        .HasColumnType("float");

                    b.Property<double>("wysokosc")
                        .HasColumnType("float");

                    b.HasKey("MiejsceId");

                    b.ToTable("Miejsca");
                });

            modelBuilder.Entity("BankZdjecOlsztyn.Models.MiejsceTag", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("MiejsceId")
                        .HasColumnType("int");

                    b.HasKey("TagId", "MiejsceId");

                    b.HasIndex("MiejsceId");

                    b.ToTable("MiejscTagi");
                });

            modelBuilder.Entity("BankZdjecOlsztyn.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tagi");
                });

            modelBuilder.Entity("BankZdjecOlsztyn.Models.Zdjecie", b =>
                {
                    b.Property<int>("ZdjecieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MiejsceId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZdjecieId");

                    b.HasIndex("MiejsceId");

                    b.ToTable("Zdjecia");
                });

            modelBuilder.Entity("BankZdjecOlsztyn.Models.MiejsceTag", b =>
                {
                    b.HasOne("BankZdjecOlsztyn.Models.Miejsce", "Miejsce")
                        .WithMany("MiejsceTag")
                        .HasForeignKey("MiejsceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankZdjecOlsztyn.Models.Tag", "Tag")
                        .WithMany("MiejsceTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BankZdjecOlsztyn.Models.Zdjecie", b =>
                {
                    b.HasOne("BankZdjecOlsztyn.Models.Miejsce", "Miejsce")
                        .WithMany("ZdieciaList")
                        .HasForeignKey("MiejsceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
