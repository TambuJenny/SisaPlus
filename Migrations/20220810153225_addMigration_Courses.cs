using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sisaplus.Migrations
{
    public partial class addMigration_Courses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_CourseModel_CourseId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseModel",
                table: "CourseModel");

            migrationBuilder.RenameTable(
                name: "CourseModel",
                newName: "Courses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "CourseModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseModel",
                table: "CourseModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_CourseModel_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "CourseModel",
                principalColumn: "Id");
        }
    }
}
