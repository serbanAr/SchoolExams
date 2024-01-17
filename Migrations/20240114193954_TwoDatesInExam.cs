using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolExams.Migrations
{
    public partial class TwoDatesInExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Exam",
                newName: "Date2");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Exam",
                newName: "Date1");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Exam",
                newName: "Class2");

            migrationBuilder.AddColumn<string>(
                name: "Class1",
                table: "Exam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class1",
                table: "Exam");

            migrationBuilder.RenameColumn(
                name: "Date2",
                table: "Exam",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "Date1",
                table: "Exam",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Class2",
                table: "Exam",
                newName: "Class");
        }
    }
}
