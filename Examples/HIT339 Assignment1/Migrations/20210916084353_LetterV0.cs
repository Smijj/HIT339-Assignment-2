using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HIT339_Assignment1.Migrations
{
    public partial class LetterV0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LetterId",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Letter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bsb = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    accountNumber = table.Column<int>(type: "int", nullable: false),
                    currentTerm = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    currentSemester = table.Column<int>(type: "int", nullable: false),
                    currentYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    termStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letter", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_LetterId",
                table: "Lesson",
                column: "LetterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Letter_LetterId",
                table: "Lesson",
                column: "LetterId",
                principalTable: "Letter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Letter_LetterId",
                table: "Lesson");

            migrationBuilder.DropTable(
                name: "Letter");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_LetterId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "LetterId",
                table: "Lesson");
        }
    }
}
