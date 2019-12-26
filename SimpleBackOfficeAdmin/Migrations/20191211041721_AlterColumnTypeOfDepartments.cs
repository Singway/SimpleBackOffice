using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBackOfficeAdmin.Migrations
{
    public partial class AlterColumnTypeOfDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptCode", "DeptName", "Description", "Subordinate" },
                values: new object[] { 2, "101", "HomeOffice", "总部", "0" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptCode", "DeptName", "Description", "Subordinate" },
                values: new object[] { 1, "100", "Back-Office Admin", "后台操作管理人员分组，拥有几乎所有权限", "0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptCode", "DeptName", "Description", "Subordinate" },
                values: new object[] { 2, 101, "HomeOffice", "总部", 0 });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptCode", "DeptName", "Description", "Subordinate" },
                values: new object[] { 1, 100, "Back-Office Admin", "后台操作管理人员分组，拥有几乎所有权限", 0 });
        }
    }
}
