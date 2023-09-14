using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlacementTestMangement.Server.Migrations
{
    public partial class editStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForEmergenciesName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ForEmergenciesNumber",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "HomeNumber",
                table: "Students",
                newName: "Note");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Students",
                newName: "HomeNumber");

            migrationBuilder.AddColumn<string>(
                name: "ForEmergenciesName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForEmergenciesNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
