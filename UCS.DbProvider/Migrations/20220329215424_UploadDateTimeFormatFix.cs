using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCS.DbProvider.Migrations
{
    public partial class UploadDateTimeFormatFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadDateTime",
                table: "Images",
                newName: "UploadImageDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadImageDateTime",
                table: "Images",
                newName: "UploadDateTime");
        }
    }
}
