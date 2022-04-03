using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UCS.DbProvider.Migrations
{
    public partial class TopicRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TopicRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TopicId = table.Column<int>(type: "integer", nullable: false),
                    QuestionTypeId = table.Column<int>(type: "integer", nullable: false),
                    QuestionThemeId = table.Column<int>(type: "integer", nullable: false),
                    QuestionsCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicRule_QuestionThemes_QuestionThemeId",
                        column: x => x.QuestionThemeId,
                        principalTable: "QuestionThemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicRule_QuestionTypes_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicRule_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicRule_QuestionThemeId",
                table: "TopicRule",
                column: "QuestionThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicRule_QuestionTypeId",
                table: "TopicRule",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicRule_TopicId",
                table: "TopicRule",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicRule");
        }
    }
}
