using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCS.DbProvider.Migrations
{
    public partial class ImageFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadImageDatetime",
                table: "Images",
                newName: "UploadImageDateTime");

            migrationBuilder.RenameColumn(
                name: "UploadImageDateTime",
                table: "Images",
                newName: "UploadDatetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadImageDateTime",
                table: "Images",
                newName: "UploadImageDatetime");

            migrationBuilder.RenameColumn(
                name: "UploadDatetime",
                table: "Images",
                newName: "UploadImageDateTime");
        }
    }
}
