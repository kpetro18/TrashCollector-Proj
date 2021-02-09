using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "488d3e17-aa6d-4830-9c07-0c9ab79950b5");

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    CompletedPickup = table.Column<bool>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountDue = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    DayId = table.Column<int>(nullable: false),
                    AdditionalPickup = table.Column<bool>(nullable: false),
                    ExtraPickupDay = table.Column<DateTime>(nullable: false),
                    SuspendedPickup = table.Column<bool>(nullable: false),
                    SuspendPickupStart = table.Column<DateTime>(nullable: false),
                    SuspendPickupEnd = table.Column<DateTime>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b0343d9-17ee-4b99-bd9d-9a067c829836", "2d122850-223c-4dd5-92b9-fd54cfb148c9", "Admin", "ADMIN" },
                    { "ff3b9fe6-62cc-4e10-897e-88291c072874", "ebcff8bb-7aa0-4359-b222-8c733e0eed74", "Customer", "CUSTOMER" },
                    { "3797cd0f-d7e6-43b7-8f07-faf148c237f3", "95dd6468-3e73-4794-a506-e84a486d8516", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sunday" },
                    { 2, "Monday" },
                    { 3, "Tuesday" },
                    { 4, "Wednesday" },
                    { 5, "Thursday" },
                    { 6, "Friday" },
                    { 7, "Saturday" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DayId",
                table: "Customers",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentityUserId",
                table: "Customers",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdentityUserId",
                table: "Employees",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3797cd0f-d7e6-43b7-8f07-faf148c237f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b0343d9-17ee-4b99-bd9d-9a067c829836");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff3b9fe6-62cc-4e10-897e-88291c072874");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "488d3e17-aa6d-4830-9c07-0c9ab79950b5", "5c77a84a-7ded-4ebe-a724-834acf4ecc27", "Admin", "ADMIN" });
        }
    }
}
