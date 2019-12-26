using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBackOfficeAdmin.Migrations
{
    public partial class AddDeptSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Dept_DeptCode",
                table: "Departments");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptCode", "DeptName", "Description", "Subordinate" },
                values: new object[] { 1, 100, "Back-Office Admin", "后台操作管理人员分组，拥有几乎所有权限", 0 });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptCode", "DeptName", "Description", "Subordinate" },
                values: new object[] { 2, 101, "HomeOffice", "总部", 0 });
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

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Dept_DeptCode",
                table: "Departments",
                sql: "alter table Departments add constraint CK_Dept_DeptCode check (DeptCode>=100 and DeptCode<=299) ");
        }
    }
}
