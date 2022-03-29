using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCS.DbProvider.Migrations
{
    public partial class ImageInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageBytes",
                table: "Images",
                type: "bytea",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBytes",
                table: "Images");
        }
    }
}
