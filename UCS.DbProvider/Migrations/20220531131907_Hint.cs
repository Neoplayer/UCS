using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCS.DbProvider.Migrations
{
    public partial class Hint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HintImageId",
                table: "Questions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_HintImageId",
                table: "Questions",
                column: "HintImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Images_HintImageId",
                table: "Questions",
                column: "HintImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Images_HintImageId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_HintImageId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "HintImageId",
                table: "Questions");
        }
    }
}
