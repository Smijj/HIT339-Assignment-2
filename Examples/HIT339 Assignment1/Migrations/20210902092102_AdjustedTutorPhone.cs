using Microsoft.EntityFrameworkCore.Migrations;

namespace HIT339_Assignment1.Migrations
{
    public partial class AdjustedTutorPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "termYear",
                table: "Lesson",
                newName: "Term");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Tutor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Term",
                table: "Lesson",
                newName: "termYear");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Tutor",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
