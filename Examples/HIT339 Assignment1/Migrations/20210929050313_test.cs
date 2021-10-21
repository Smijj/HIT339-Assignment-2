using Microsoft.EntityFrameworkCore.Migrations;

namespace HIT339_Assignment1.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Letter_LetterId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Letter_LetterId1",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_LetterId1",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "currentSemester",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "LetterId1",
                table: "Lesson");

            migrationBuilder.RenameColumn(
                name: "LetterId",
                table: "Lesson",
                newName: "letterId");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_LetterId",
                table: "Lesson",
                newName: "IX_Lesson_letterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Letter_letterId",
                table: "Lesson",
                column: "letterId",
                principalTable: "Letter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Letter_letterId",
                table: "Lesson");

            migrationBuilder.RenameColumn(
                name: "letterId",
                table: "Lesson",
                newName: "LetterId");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_letterId",
                table: "Lesson",
                newName: "IX_Lesson_LetterId");

            migrationBuilder.AddColumn<int>(
                name: "currentSemester",
                table: "Letter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LetterId1",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_LetterId1",
                table: "Lesson",
                column: "LetterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Letter_LetterId",
                table: "Lesson",
                column: "LetterId",
                principalTable: "Letter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Letter_LetterId1",
                table: "Lesson",
                column: "LetterId1",
                principalTable: "Letter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
