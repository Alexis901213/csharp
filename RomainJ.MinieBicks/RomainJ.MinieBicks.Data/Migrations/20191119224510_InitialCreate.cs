using Microsoft.EntityFrameworkCore.Migrations;

namespace RomainJ.MinieBicks.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "Role",
                newName: "ID_Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_Role",
                table: "Role",
                newName: "IdRole");
        }
    }
}
