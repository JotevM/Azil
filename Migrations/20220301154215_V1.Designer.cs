﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Projekat.Migrations
{
    [DbContext(typeof(AzilContext))]
    [Migration("20220301154215_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.Azil", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("brZaposlenih")
                        .HasColumnType("int");

                    b.Property<int>("brZivotinja")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("kontaktTelefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Azil");
                });

            modelBuilder.Entity("Models.Cip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("brGodina")
                        .HasColumnType("int");

                    b.Property<string>("polZ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vrstaZ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cip");
                });

            modelBuilder.Entity("Models.KartonVakcinacije", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("datumVakcinacije")
                        .HasColumnType("datetime2");

                    b.Property<string>("nazivVakcine")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("KartonVakcinacije");
                });

            modelBuilder.Entity("Models.Udomitelj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("adresaU")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("brLicneKarte")
                        .HasColumnType("int");

                    b.Property<string>("brTelefonaU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imeU")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("prezimeU")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Udomitelj");
                });

            modelBuilder.Entity("Models.Zaposleni", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AzilID")
                        .HasColumnType("int");

                    b.Property<string>("adresa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("jmbg")
                        .HasColumnType("int");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("slika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AzilID");

                    b.ToTable("Zaposleni");
                });

            modelBuilder.Entity("Models.Zivotinja", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AzilID")
                        .HasColumnType("int");

                    b.Property<int?>("CipID")
                        .HasColumnType("int");

                    b.Property<int?>("KartonVakcinacijeID")
                        .HasColumnType("int");

                    b.Property<int?>("UdomiteljID")
                        .HasColumnType("int");

                    b.Property<int?>("ZaposleniID")
                        .HasColumnType("int");

                    b.Property<int>("brCipa")
                        .HasColumnType("int");

                    b.Property<int>("brKartonaVakc")
                        .HasColumnType("int");

                    b.Property<string>("imeZ")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("AzilID");

                    b.HasIndex("CipID");

                    b.HasIndex("KartonVakcinacijeID");

                    b.HasIndex("UdomiteljID");

                    b.HasIndex("ZaposleniID");

                    b.ToTable("Zivotinja");
                });

            modelBuilder.Entity("Models.Zaposleni", b =>
                {
                    b.HasOne("Models.Azil", "Azil")
                        .WithMany("Zaposlenii")
                        .HasForeignKey("AzilID");

                    b.Navigation("Azil");
                });

            modelBuilder.Entity("Models.Zivotinja", b =>
                {
                    b.HasOne("Models.Azil", "Azil")
                        .WithMany("Zivotinje")
                        .HasForeignKey("AzilID");

                    b.HasOne("Models.Cip", "Cip")
                        .WithMany()
                        .HasForeignKey("CipID");

                    b.HasOne("Models.KartonVakcinacije", "KartonVakcinacije")
                        .WithMany()
                        .HasForeignKey("KartonVakcinacijeID");

                    b.HasOne("Models.Udomitelj", null)
                        .WithMany("Zivotinje")
                        .HasForeignKey("UdomiteljID");

                    b.HasOne("Models.Zaposleni", "Zaposleni")
                        .WithMany("Zivotinje")
                        .HasForeignKey("ZaposleniID");

                    b.Navigation("Azil");

                    b.Navigation("Cip");

                    b.Navigation("KartonVakcinacije");

                    b.Navigation("Zaposleni");
                });

            modelBuilder.Entity("Models.Azil", b =>
                {
                    b.Navigation("Zaposlenii");

                    b.Navigation("Zivotinje");
                });

            modelBuilder.Entity("Models.Udomitelj", b =>
                {
                    b.Navigation("Zivotinje");
                });

            modelBuilder.Entity("Models.Zaposleni", b =>
                {
                    b.Navigation("Zivotinje");
                });
#pragma warning restore 612, 618
        }
    }
}
