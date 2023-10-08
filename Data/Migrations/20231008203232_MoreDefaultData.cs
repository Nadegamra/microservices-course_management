using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseManagement.Migrations
{
    /// <inheritdoc />
    public partial class MoreDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "ActivityFormat", "CertificatePrice", "DetailedDescription", "Difficulty", "GrantsCertificate", "ImageId", "IsDeleted", "IsHidden", "LengthInDays", "Name", "Price", "ScheduleType", "ShortDescription", "UserId" },
                values: new object[,]
                {
                    { 1, 2, 0.00m, "Introduction to basic concepts of python", 0, false, "1d2wbDS7WVGR9Qxk1fkUtTVq1qkrAeq6q", false, false, 30, "Python Basics", 39.99m, 1, "Introduction to python", 2 },
                    { 2, 0, 0.00m, "Everything needed to dockerize a basic web app", 1, true, "", false, false, 15, "Introduction to Docker", 19.99m, 0, "Base knowledge of Docker", 2 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 13, "Command line interface", "CLI" });

            migrationBuilder.InsertData(
                table: "CourseLanguages",
                columns: new[] { "Id", "CourseId", "IsPrimary", "LanguageId" },
                values: new object[,]
                {
                    { 1, 1, true, 1 },
                    { 2, 1, false, 2 },
                    { 3, 2, false, 1 },
                    { 4, 2, true, 2 }
                });

            migrationBuilder.InsertData(
                table: "CourseRequirements",
                columns: new[] { "Id", "CourseId", "CustomDescription", "SkillId" },
                values: new object[,]
                {
                    { 1, 1, null, 3 },
                    { 2, 1, "Problem Solving", null },
                    { 3, 2, null, 13 }
                });

            migrationBuilder.InsertData(
                table: "CourseSubtitles",
                columns: new[] { "Id", "CourseId", "LanguageId" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "GainedSkills",
                columns: new[] { "Id", "CourseId", "CustomDescription", "SkillId" },
                values: new object[,]
                {
                    { 1, 1, null, 12 },
                    { 2, 1, "Agile methodologies", null },
                    { 3, 2, null, 5 },
                    { 4, 2, "Compilation", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseLanguages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseLanguages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourseLanguages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourseLanguages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourseRequirements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseRequirements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourseRequirements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourseSubtitles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseSubtitles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GainedSkills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GainedSkills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GainedSkills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GainedSkills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
