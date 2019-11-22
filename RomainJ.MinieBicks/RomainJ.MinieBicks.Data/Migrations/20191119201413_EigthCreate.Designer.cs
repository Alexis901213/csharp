﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RomainJ.MinieBicks.Data;

namespace RomainJ.MinieBicks.Data.Migrations
{
    [DbContext(typeof(MineBricksContext))]
    [Migration("20191119201413_EigthCreate")]
    partial class EigthCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("RomainJ.MinieBicks.Data.Adresse", b =>
                {
                    b.Property<int>("IdAdresse")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodePostal");

                    b.Property<int>("Numero");

                    b.Property<string>("Rue");

                    b.Property<string>("Ville");

                    b.HasKey("IdAdresse");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("RomainJ.MinieBicks.Data.Conges", b =>
                {
                    b.Property<int>("IdConge")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAbsence");

                    b.Property<int>("ID_Personne");

                    b.Property<int>("ID_TypeConges");

                    b.HasKey("IdConge");

                    b.HasIndex("ID_Personne");

                    b.HasIndex("ID_TypeConges");

                    b.ToTable("Conges");
                });

            modelBuilder.Entity("RomainJ.MinieBicks.Data.Personne", b =>
                {
                    b.Property<int>("IdPersonne")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ID_Adresse");

                    b.Property<int>("ID_Role");

                    b.Property<string>("Nom");

                    b.Property<int>("NombreCongesAnnuelsCumules");

                    b.Property<int>("NombreRTTCumules");

                    b.Property<string>("Prenom");

                    b.Property<int?>("SuperieurIdPersonne");

                    b.HasKey("IdPersonne");

                    b.HasIndex("ID_Adresse");

                    b.HasIndex("ID_Role");

                    b.HasIndex("SuperieurIdPersonne");

                    b.ToTable("Personne");
                });

            modelBuilder.Entity("RomainJ.MinieBicks.Data.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom");

                    b.HasKey("IdRole");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("RomainJ.MinieBicks.Data.TypeConges", b =>
                {
                    b.Property<int>("IdTypeConges")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("JoursConges");

                    b.Property<string>("Libelle");

                    b.Property<bool>("ValidationObligatoire");

                    b.HasKey("IdTypeConges");

                    b.ToTable("TypeConges");
                });

            modelBuilder.Entity("RomainJ.MinieBicks.Data.Conges", b =>
                {
                    b.HasOne("RomainJ.MinieBicks.Data.Personne", "Personne")
                        .WithMany()
                        .HasForeignKey("ID_Personne")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RomainJ.MinieBicks.Data.TypeConges", "TypeConges")
                        .WithMany()
                        .HasForeignKey("ID_TypeConges")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RomainJ.MinieBicks.Data.Personne", b =>
                {
                    b.HasOne("RomainJ.MinieBicks.Data.Adresse", "Adresse")
                        .WithMany()
                        .HasForeignKey("ID_Adresse")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RomainJ.MinieBicks.Data.Role", "Role")
                        .WithMany()
                        .HasForeignKey("ID_Role")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RomainJ.MinieBicks.Data.Personne", "Superieur")
                        .WithMany()
                        .HasForeignKey("SuperieurIdPersonne");
                });
#pragma warning restore 612, 618
        }
    }
}
