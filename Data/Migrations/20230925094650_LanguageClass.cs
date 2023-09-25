using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseManagement.Migrations
{
    /// <inheritdoc />
    public partial class LanguageClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Language",
                table: "CourseSubtitles",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "CourseLanguages",
                newName: "LanguageId");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubtitles_LanguageId",
                table: "CourseSubtitles",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLanguages_LanguageId",
                table: "CourseLanguages",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseLanguages_Languages_LanguageId",
                table: "CourseLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubtitles_Languages_LanguageId",
                table: "CourseSubtitles",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseLanguages_Languages_LanguageId",
                table: "CourseLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubtitles_Languages_LanguageId",
                table: "CourseSubtitles");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_CourseSubtitles_LanguageId",
                table: "CourseSubtitles");

            migrationBuilder.DropIndex(
                name: "IX_CourseLanguages_LanguageId",
                table: "CourseLanguages");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "CourseSubtitles",
                newName: "Language");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "CourseLanguages",
                newName: "Language");
        }
    }
}
