using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanoKaam.Migrations
{
    public partial class addPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applieds_Jobs_JobId",
                table: "Applieds");

            migrationBuilder.DropIndex(
                name: "IX_Applieds_JobId",
                table: "Applieds");

            migrationBuilder.DropColumn(
                name: "AppliedId",
                table: "Profiles");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Profiles",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Applieds_AppliedId",
                table: "Applieds",
                column: "AppliedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applieds_Jobs_AppliedId",
                table: "Applieds",
                column: "AppliedId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applieds_Jobs_AppliedId",
                table: "Applieds");

            migrationBuilder.DropIndex(
                name: "IX_Applieds_AppliedId",
                table: "Applieds");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "AppliedId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applieds_JobId",
                table: "Applieds",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applieds_Jobs_JobId",
                table: "Applieds",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
