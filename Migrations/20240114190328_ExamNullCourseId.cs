using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolExams.Migrations
{
    public partial class ExamNullCourseId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Course_CourseId",
                table: "Exam");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Exam",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Course_CourseId",
                table: "Exam",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Course_CourseId",
                table: "Exam");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Exam",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Course_CourseId",
                table: "Exam",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
