using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanoKaam.Migrations
{
    public partial class companylogotoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CompanyLogo",
                table: "Jobs",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyLogo",
                table: "Jobs");
        }
    }
}
