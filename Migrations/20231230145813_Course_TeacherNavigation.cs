using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolExams.Migrations
{
    public partial class Course_TeacherNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeacherId",
                table: "Course",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Teacher_TeacherId",
                table: "Course",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Teacher_TeacherId",
                table: "Course");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Course_TeacherId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Course");
        }
    }
}
