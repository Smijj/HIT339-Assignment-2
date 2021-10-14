using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentOne_CYCC.Migrations
{
    public partial class InvoiceLessonFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Invoice_lesson",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_lesson",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "lesson",
                table: "Lesson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lesson",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_lesson",
                table: "Lesson",
                column: "lesson");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Invoice_lesson",
                table: "Lesson",
                column: "lesson",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
