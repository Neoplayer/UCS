using Microsoft.EntityFrameworkCore.Migrations;

namespace UCS.DbProvider.Migrations
{
    public partial class fixMessageDatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChatCreationDateTime",
                table: "Messages",
                newName: "DateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Messages",
                newName: "ChatCreationDateTime");
        }
    }
}
