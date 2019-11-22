using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RomainJ.MinieBicks.Data.Migrations
{
    public partial class EigthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    IdAdresse = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<int>(nullable: false),
                    Rue = table.Column<string>(nullable: true),
                    Ville = table.Column<string>(nullable: true),
                    CodePostal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.IdAdresse);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    IdRole = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "TypeConges",
                columns: table => new
                {
                    IdTypeConges = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JoursConges = table.Column<int>(nullable: false),
                    Libelle = table.Column<string>(nullable: true),
                    ValidationObligatoire = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeConges", x => x.IdTypeConges);
                });

            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    IdPersonne = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    SuperieurIdPersonne = table.Column<int>(nullable: true),
                    NombreCongesAnnuelsCumules = table.Column<int>(nullable: false),
                    NombreRTTCumules = table.Column<int>(nullable: false),
                    ID_Role = table.Column<int>(nullable: false),
                    ID_Adresse = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.IdPersonne);
                    table.ForeignKey(
                        name: "FK_Personne_Adresses_ID_Adresse",
                        column: x => x.ID_Adresse,
                        principalTable: "Adresses",
                        principalColumn: "IdAdresse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personne_Role_ID_Role",
                        column: x => x.ID_Role,
                        principalTable: "Role",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personne_Personne_SuperieurIdPersonne",
                        column: x => x.SuperieurIdPersonne,
                        principalTable: "Personne",
                        principalColumn: "IdPersonne",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conges",
                columns: table => new
                {
                    IdConge = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateAbsence = table.Column<DateTime>(nullable: false),
                    ID_Personne = table.Column<int>(nullable: false),
                    ID_TypeConges = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conges", x => x.IdConge);
                    table.ForeignKey(
                        name: "FK_Conges_Personne_ID_Personne",
                        column: x => x.ID_Personne,
                        principalTable: "Personne",
                        principalColumn: "IdPersonne",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conges_TypeConges_ID_TypeConges",
                        column: x => x.ID_TypeConges,
                        principalTable: "TypeConges",
                        principalColumn: "IdTypeConges",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conges_ID_Personne",
                table: "Conges",
                column: "ID_Personne");

            migrationBuilder.CreateIndex(
                name: "IX_Conges_ID_TypeConges",
                table: "Conges",
                column: "ID_TypeConges");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_ID_Adresse",
                table: "Personne",
                column: "ID_Adresse");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_ID_Role",
                table: "Personne",
                column: "ID_Role");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_SuperieurIdPersonne",
                table: "Personne",
                column: "SuperieurIdPersonne");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conges");

            migrationBuilder.DropTable(
                name: "Personne");

            migrationBuilder.DropTable(
                name: "TypeConges");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
