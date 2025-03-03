using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeros.Migrations
{
    public partial class Adding_teacher_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassTeacher",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "ClassTeacher",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
