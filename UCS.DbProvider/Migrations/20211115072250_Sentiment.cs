using Microsoft.EntityFrameworkCore.Migrations;

namespace UCS.DbProvider.Migrations
{
    public partial class Sentiment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Sentiment",
                table: "Messages",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sentiment",
                table: "Messages");
        }
    }
}
