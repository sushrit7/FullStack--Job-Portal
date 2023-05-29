using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanoKaam.Migrations
{
    public partial class addskills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Start",
                table: "Profiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Start",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
