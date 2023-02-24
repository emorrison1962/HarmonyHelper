using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HarmonyHelper.Dal.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class _04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Intervals",
                columns: new[] { "Id", "IntervalRoleType", "Name", "SemiTones", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Diminished2nd", 0, 1 },
                    { 2, 0, "Augmented Unison", 1, 2 },
                    { 3, 1, "Minor2nd", 1, 2 },
                    { 4, 1, "Major2nd", 2, 4 },
                    { 5, 2, "Diminished3rd", 2, 4 },
                    { 6, 1, "Augmented2nd", 3, 8 },
                    { 7, 2, "Minor3rd", 3, 8 },
                    { 8, 2, "Major3rd", 4, 16 },
                    { 9, 3, "Diminished4th", 4, 16 },
                    { 10, 3, "Perfect4th", 5, 32 },
                    { 11, 2, "Augmented3rd", 5, 32 },
                    { 12, 3, "Augmented4th", 6, 64 },
                    { 13, 4, "Diminished5th", 6, 64 },
                    { 14, 4, "Perfect5th", 7, 128 },
                    { 15, 5, "Diminished6th", 7, 128 },
                    { 16, 4, "Augmented5th", 8, 256 },
                    { 17, 5, "Minor6th", 8, 256 },
                    { 18, 5, "Major6th", 9, 512 },
                    { 19, 5, "Augmented6th", 10, 1024 },
                    { 20, 6, "Diminished7th", 9, 512 },
                    { 21, 6, "Minor7th", 10, 1024 },
                    { 22, 6, "Major7th", 11, 2048 },
                    { 23, 7, "Diminished Octave", 11, 2048 },
                    { 24, 7, "Perfect Octave", 12, 1 },
                    { 25, 6, "Augmented7th", 12, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Intervals",
                keyColumn: "Id",
                keyValue: 25);
        }
    }
}
