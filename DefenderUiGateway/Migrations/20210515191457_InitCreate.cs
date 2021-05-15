using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DefenderUiGateway.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Passport = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreditIndex = table.Column<int>(type: "int", nullable: false),
                    RatingMin = table.Column<int>(type: "int", nullable: false),
                    RatingMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersLastPolling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Passport = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastPolled = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLastPolling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BkiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditRequests_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    InActionSince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Payment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Credits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pushes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Since = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pushed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pushes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pushes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Created", "Name", "RegistrationNumber", "Tin" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 15, 22, 14, 57, 586, DateTimeKind.Local).AddTicks(7903), "МФО \"Копеечка онлайн\"", "8503708019", "75034648" },
                    { 2, new DateTime(2021, 5, 15, 22, 14, 57, 586, DateTimeKind.Local).AddTicks(8904), "СберБанк", "1234143124", "3434343" },
                    { 3, new DateTime(2021, 5, 15, 22, 14, 57, 586, DateTimeKind.Local).AddTicks(8908), "Тинькофф", "4536556456", "45645645" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "CreditIndex", "Name", "Passport", "Phone", "RatingMax", "RatingMin" },
                values: new object[] { 1, new DateTime(2021, 5, 15, 22, 14, 57, 585, DateTimeKind.Local).AddTicks(1865), 707, "Сидоров Иван Петрович", "1111222222", "+7(123)1234567", 850, 300 });

            migrationBuilder.InsertData(
                table: "UsersLastPolling",
                columns: new[] { "Id", "Created", "LastPolled", "Passport", "Updated" },
                values: new object[] { 1, new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(4010), new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(4507), "1111222222", null });

            migrationBuilder.InsertData(
                table: "CreditRequests",
                columns: new[] { "Id", "BankId", "BkiId", "Created", "OrderDate", "UserId" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(2453), new DateTime(2021, 5, 10, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(3201), 1 },
                    { 2, 2, null, new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(3456), new DateTime(2021, 5, 12, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(3458), 1 },
                    { 3, 3, null, new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(3459), new DateTime(2021, 5, 13, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(3461), 1 }
                });

            migrationBuilder.InsertData(
                table: "Credits",
                columns: new[] { "Id", "BankId", "Created", "InActionSince", "PaidSum", "Payment", "PaymentDateTime", "StateId", "TotalSum", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2021, 5, 15, 22, 14, 57, 586, DateTimeKind.Local).AddTicks(9540), new DateTime(2021, 5, 5, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(13), 0m, 50000m, new DateTime(2021, 5, 10, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1385), 1, 200000m, 1 },
                    { 2, 2, new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1852), new DateTime(2021, 5, 9, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1856), 90000m, 45000m, new DateTime(2021, 5, 12, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1859), 0, 500000m, 1 },
                    { 3, 3, new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1860), new DateTime(2021, 5, 11, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1861), 3000m, 3000m, new DateTime(2021, 5, 13, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1862), 0, 150000m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditRequests_BankId",
                table: "CreditRequests",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditRequests_BkiId",
                table: "CreditRequests",
                column: "BkiId",
                unique: true,
                filter: "[BkiId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CreditRequests_UserId",
                table: "CreditRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_BankId",
                table: "Credits",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_UserId",
                table: "Credits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pushes_UserId",
                table: "Pushes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Passport",
                table: "Users",
                column: "Passport",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersLastPolling_Passport",
                table: "UsersLastPolling",
                column: "Passport",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditRequests");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "Pushes");

            migrationBuilder.DropTable(
                name: "UsersLastPolling");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
