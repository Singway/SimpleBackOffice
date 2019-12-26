using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBackOfficeAdmin.Migrations
{
    public partial class delectUselessOfDBLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Callsite",
                table: "DBLogs");

            migrationBuilder.DropColumn(
                name: "Operatingaddress",
                table: "DBLogs");

            migrationBuilder.DropColumn(
                name: "Referrerurl",
                table: "DBLogs");

            migrationBuilder.DropColumn(
                name: "WindowsName",
                table: "DBLogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Callsite",
                table: "DBLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Operatingaddress",
                table: "DBLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Referrerurl",
                table: "DBLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WindowsName",
                table: "DBLogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
