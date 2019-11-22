using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RomainJ.MinieBicks.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    IdPersonne = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    SuperieurIdPersonne = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.IdPersonne);
                    table.ForeignKey(
                        name: "FK_Personne_Personne_SuperieurIdPersonne",
                        column: x => x.SuperieurIdPersonne,
                        principalTable: "Personne",
                        principalColumn: "IdPersonne",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    IdRole = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.IdRole);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personne_SuperieurIdPersonne",
                table: "Personne",
                column: "SuperieurIdPersonne");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personne");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
