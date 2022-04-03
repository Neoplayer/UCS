using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCS.DbProvider.Migrations
{
    public partial class ImageFix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadDatetime",
                table: "Images",
                newName: "UploadDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadDateTime",
                table: "Images",
                newName: "UploadDatetime");
        }
    }
}
