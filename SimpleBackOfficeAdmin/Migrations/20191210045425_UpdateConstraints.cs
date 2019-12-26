using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBackOfficeAdmin.Migrations
{
    public partial class UpdateConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_Dept_DeptName",
                table: "Departments");



            migrationBuilder.AlterColumn<int>(
                name: "Subordinate",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DeptCode",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_Dept_DeptCode",
                table: "Departments",
                column: "DeptCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_Dept_DeptCode",
                table: "Departments");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Dept_DeptCode",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "Subordinate",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "DeptCode",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_Dept_DeptName",
                table: "Departments",
                column: "DeptName");
        }
    }
}
