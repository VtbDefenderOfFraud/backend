using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bki.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "__stub");

            migrationBuilder.CreateTable(
                name: "__stub_query_data",
                schema: "__stub",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    long1 = table.Column<long>(type: "bigint", nullable: true),
                    long2 = table.Column<long>(type: "bigint", nullable: true),
                    long3 = table.Column<long>(type: "bigint", nullable: true),
                    double1 = table.Column<double>(type: "float", nullable: true),
                    double2 = table.Column<double>(type: "float", nullable: true),
                    double3 = table.Column<double>(type: "float", nullable: true),
                    string1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    string2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    string3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    date2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    date3 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    guid1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    guid2 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    guid3 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___stub_query_data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Passport = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credits_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[] { 1, new DateTime(2021, 5, 15, 22, 14, 25, 51, DateTimeKind.Local).AddTicks(9209), "МФО \"Копеечка онлайн\"" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[] { 2, new DateTime(2021, 5, 15, 22, 14, 25, 53, DateTimeKind.Local).AddTicks(106), "СберБанк" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[] { 3, new DateTime(2021, 5, 15, 22, 14, 25, 53, DateTimeKind.Local).AddTicks(116), "Тинькофф" });

            migrationBuilder.CreateIndex(
                name: "IX_Credits_BankId",
                table: "Credits",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_Passport",
                table: "Credits",
                column: "Passport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__stub_query_data",
                schema: "__stub");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
