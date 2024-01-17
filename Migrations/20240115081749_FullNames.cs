using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolExams.Migrations
{
    public partial class FullNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teacher",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Student",
                newName: "Lastname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Teacher",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Student",
                newName: "Name");
        }
    }
}
