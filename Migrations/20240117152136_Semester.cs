using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolExams.Migrations
{
    public partial class Semester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Student",
                newName: "Semester");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Semester",
                table: "Student",
                newName: "Year");
        }
    }
}
