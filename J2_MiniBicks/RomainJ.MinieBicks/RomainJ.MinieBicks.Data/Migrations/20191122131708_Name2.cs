using Microsoft.EntityFrameworkCore.Migrations;

namespace RomainJ.MinieBicks.Data.Migrations
{
    public partial class Name2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "pays",
                table: "TypeConges",
                newName: "Pays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pays",
                table: "TypeConges",
                newName: "pays");
        }
    }
}
