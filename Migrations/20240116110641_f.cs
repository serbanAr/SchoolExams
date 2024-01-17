using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolExams.Migrations
{
    public partial class f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Field",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollment",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEnrollment", x => new { x.CoursesId, x.EnrollmentsId });
                    table.ForeignKey(
                        name: "FK_CourseEnrollment_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEnrollment_Enrollment_EnrollmentsId",
                        column: x => x.EnrollmentsId,
                        principalTable: "Enrollment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentStudent",
                columns: table => new
                {
                    EnrollmentsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentStudent", x => new { x.EnrollmentsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_EnrollmentStudent_Enrollment_EnrollmentsId",
                        column: x => x.EnrollmentsId,
                        principalTable: "Enrollment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrollmentStudent_Student_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_FieldId",
                table: "Student",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_FieldId",
                table: "Course",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollment_EnrollmentsId",
                table: "CourseEnrollment",
                column: "EnrollmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentStudent_StudentsId",
                table: "EnrollmentStudent",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Field_FieldId",
                table: "Course",
                column: "FieldId",
                principalTable: "Field",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Field_FieldId",
                table: "Student",
                column: "FieldId",
                principalTable: "Field",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Field_FieldId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Field_FieldId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "CourseEnrollment");

            migrationBuilder.DropTable(
                name: "EnrollmentStudent");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Student_FieldId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Course_FieldId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "Field",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
