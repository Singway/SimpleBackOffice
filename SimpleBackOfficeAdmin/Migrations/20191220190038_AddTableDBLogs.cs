using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBackOfficeAdmin.Migrations
{
    public partial class AddTableDBLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(nullable: true),
                    Operatingtime = table.Column<string>(nullable: true),
                    Operatingaddress = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Identity = table.Column<string>(nullable: true),
                    WindowsName = table.Column<string>(nullable: true),
                    Logger = table.Column<string>(nullable: true),
                    Callsite = table.Column<string>(nullable: true),
                    Requesturl = table.Column<string>(nullable: true),
                    Referrerurl = table.Column<string>(nullable: true),
                    Method = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Exception = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBLogs");
        }
    }
}
