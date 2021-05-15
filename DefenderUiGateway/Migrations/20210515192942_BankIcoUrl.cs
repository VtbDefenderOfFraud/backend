using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenderUiGateway.Migrations
{
    public partial class BankIcoUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IcoUrl",
                table: "Banks");
        }
    }
}
