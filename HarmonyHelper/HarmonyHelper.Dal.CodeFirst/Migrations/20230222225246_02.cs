using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HarmonyHelper.Dal.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class _02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NoteNames",
                columns: new[] { "Id", "AsciiSortValue", "IsFlatted", "IsNatural", "IsSharped", "Name", "Value" },
                values: new object[,]
                {
                    { 1, 0, false, true, false, "C", 2 },
                    { 2, 0, false, false, true, "C♯", 4 },
                    { 3, 1, true, false, false, "D♭", 4 },
                    { 4, 1, false, true, false, "D", 8 },
                    { 5, 1, false, false, true, "D♯", 16 },
                    { 6, 2, true, false, false, "E♭", 16 },
                    { 7, 2, false, true, false, "E", 32 },
                    { 8, 3, true, false, false, "F♭", 32 },
                    { 9, 2, false, false, true, "E♯", 64 },
                    { 10, 3, false, true, false, "F", 64 },
                    { 11, 3, false, false, true, "F♯", 128 },
                    { 12, 4, true, false, false, "G♭", 128 },
                    { 13, 4, false, true, false, "G", 256 },
                    { 14, 4, false, false, true, "G♯", 512 },
                    { 15, 5, true, false, false, "A♭", 512 },
                    { 16, 5, false, true, false, "A", 1024 },
                    { 17, 5, false, false, true, "A♯", 2048 },
                    { 18, 6, true, false, false, "B♭", 2048 },
                    { 19, 6, false, true, false, "B", 4096 },
                    { 20, 0, true, false, false, "C♭", 4096 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "NoteNames",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
