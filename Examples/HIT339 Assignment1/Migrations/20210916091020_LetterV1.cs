using Microsoft.EntityFrameworkCore.Migrations;

namespace HIT339_Assignment1.Migrations
{
    public partial class LetterV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
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
                name: "IX_Letter_StudentId",
                table: "Letter",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_LetterId1",
                table: "Lesson",
                column: "LetterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Letter_LetterId1",
                table: "Lesson",
                column: "LetterId1",
                principalTable: "Letter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Letter_Student_StudentId",
                table: "Letter",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Letter_LetterId1",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Letter_Student_StudentId",
                table: "Letter");

            migrationBuilder.DropIndex(
                name: "IX_Letter_StudentId",
                table: "Letter");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_LetterId1",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "LetterId1",
                table: "Lesson");
        }
    }
}
