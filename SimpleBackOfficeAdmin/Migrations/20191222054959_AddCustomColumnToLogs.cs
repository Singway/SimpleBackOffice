using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBackOfficeAdmin.Migrations
{
    public partial class AddCustomColumnToLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomProperty",
                table: "DBLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomProperty",
                table: "DBLogs");
        }
    }
}
