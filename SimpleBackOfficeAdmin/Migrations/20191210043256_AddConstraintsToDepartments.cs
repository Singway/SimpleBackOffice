using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBackOfficeAdmin.Migrations
{
    public partial class AddConstraintsToDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subordinate",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DeptCode",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_Dept_DeptName",
                table: "Departments",
                column: "DeptName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_Dept_DeptName",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "Subordinate",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "DeptCode",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
