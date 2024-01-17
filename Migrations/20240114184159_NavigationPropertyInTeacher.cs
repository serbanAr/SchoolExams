using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolExams.Migrations
{
    public partial class NavigationPropertyInTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Exam_CourseId",
                table: "Exam");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_CourseId",
                table: "Exam",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Exam_CourseId",
                table: "Exam");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_CourseId",
                table: "Exam",
                column: "CourseId",
                unique: true);
        }
    }
}
