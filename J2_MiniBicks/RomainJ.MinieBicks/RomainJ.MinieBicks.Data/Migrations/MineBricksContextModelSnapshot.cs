﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RomainJ.MinieBicks.Data;

namespace RomainJ.MinieBicks.Data.Migrations
{
    [DbContext(typeof(MineBricksContext))]
    partial class MineBricksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1");

            modelBuilder.Entity("RomainJ.MinieBicks.Data.Adresse", b =>
                {
                    b.Property<int>("IdAdresse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CodePostal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rue")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ville")
                        .HasColumnType("TEXT");

                    b.HasKey("IdAdresse");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("RomainJ.MinieBicks.Data.Conges", b =>
                {
                    b.Property<int>("IdConge")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAbsenceDebut")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateAbsenceFin")
                        .HasColumnType("TEXT");

                    b.Property<int>("ID_Personne")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ID_TypeConges")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdConge");

                    b.HasIndex("ID_Personne");

                    b.HasIndex("ID_TypeConges");

                    b.ToTable("Conges");
                });

            modelBuilder.Entity("RomainJ.MinieBicks.Data.Personne", b =>
                {
                    b.Property<int>("IdPersonne")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ID_Adresse")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ID_Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<int>("NombreCongesAnnuelsCumules")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NombreRTTCumules")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Prenom")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SuperieurIdPersonne")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdPersonne");

                    b.HasIndex("ID_Adresse");

                    b.HasIndex("ID_Role");

                    b.HasIndex("SuperieurIdPersonne");

                    b.ToTable("Personne");
                });

            modelBuilder.Entity("RomainJ.MinieBicks.Data.Role", b =>
                {
                    b.Property<int>("ID_Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.HasKey("ID_Role");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("RomainJ.MinieBicks.Data.TypeConges", b =>
                {
                    b.Property<int>("IdTypeConges")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("JoursConges")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Libelle")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pays")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ValidationObligatoire")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdTypeConges");

                    b.ToTable("TypeConges");
                });

            modelBuilder.Entity("RomainJ.MinieBicks.Data.Conges", b =>
                {
                    b.HasOne("RomainJ.MinieBicks.Data.Personne", "Personne")
                        .WithMany()
                        .HasForeignKey("ID_Personne")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RomainJ.MinieBicks.Data.TypeConges", "TypeConges")
                        .WithMany()
                        .HasForeignKey("ID_TypeConges")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RomainJ.MinieBicks.Data.Personne", b =>
                {
                    b.HasOne("RomainJ.MinieBicks.Data.Adresse", "Adresse")
                        .WithMany()
                        .HasForeignKey("ID_Adresse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RomainJ.MinieBicks.Data.Role", "Role")
                        .WithMany()
                        .HasForeignKey("ID_Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RomainJ.MinieBicks.Data.Personne", "Superieur")
                        .WithMany()
                        .HasForeignKey("SuperieurIdPersonne");
                });
#pragma warning restore 612, 618
        }
    }
}
