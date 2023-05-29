using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanoKaam.Migrations
{
    public partial class addapplycolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Applies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Applies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Applies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Applies",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Applies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applies_ProfileId",
                table: "Applies",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applies_Profiles_ProfileId",
                table: "Applies",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applies_Profiles_ProfileId",
                table: "Applies");

            migrationBuilder.DropIndex(
                name: "IX_Applies_ProfileId",
                table: "Applies");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Applies");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Applies");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Applies");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Applies");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Applies");
        }
    }
}
