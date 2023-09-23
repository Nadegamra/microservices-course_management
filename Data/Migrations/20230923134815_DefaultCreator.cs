using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseManagement.Migrations
{
    /// <inheritdoc />
    public partial class DefaultCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Creators",
                columns: new[] { "Id", "Bio", "Email", "NormalizedEmail", "NormalizedUsername", "Username", "Website" },
                values: new object[] { 2, "", "creator@example.com", "CREATOR@EXAMPLE.COM", "CREATOR@EXAMPLE.COM", "creator@example.com", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Creators",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
