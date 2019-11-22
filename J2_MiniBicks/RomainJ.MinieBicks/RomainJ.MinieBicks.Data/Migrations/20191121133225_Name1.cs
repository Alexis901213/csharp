using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RomainJ.MinieBicks.Data.Migrations
{
    public partial class Name1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "DateAbsence",
            //    table: "Conges");

            migrationBuilder.AddColumn<string>(
                name: "pays",
                table: "TypeConges",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAbsenceDebut",
                table: "Conges",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAbsenceFin",
                table: "Conges",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pays",
                table: "TypeConges");

            migrationBuilder.DropColumn(
                name: "DateAbsenceDebut",
                table: "Conges");

            migrationBuilder.DropColumn(
                name: "DateAbsenceFin",
                table: "Conges");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAbsence",
                table: "Conges",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
