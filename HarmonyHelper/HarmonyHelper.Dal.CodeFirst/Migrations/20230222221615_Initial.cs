using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarmonyHelper.Dal.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    IsSharped = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFlatted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsNatural = table.Column<bool>(type: "INTEGER", nullable: false),
                    AsciiSortValue = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteNames", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteNames");
        }
    }
}
