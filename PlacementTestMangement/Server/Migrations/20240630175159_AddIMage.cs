using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlacementTestMangement.Server.Migrations
{
    public partial class AddIMage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Questions");
        }
    }
}
