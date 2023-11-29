using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Perscription.Migrations
{
    /// <inheritdoc />
    public partial class AppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.IdUser);
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "IdUser", "Login", "Password" },
                values: new object[,]
                {
                    { 1, "Adam", "123123123" },
                    { 2, "Kasia", "Password" }
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 23, 47, 0, 249, DateTimeKind.Local).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 23, 47, 0, 249, DateTimeKind.Local).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 23, 23, 47, 0, 249, DateTimeKind.Local).AddTicks(3879), new DateTime(2023, 5, 23, 23, 47, 0, 249, DateTimeKind.Local).AddTicks(3881) });

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 23, 23, 47, 0, 249, DateTimeKind.Local).AddTicks(3886), new DateTime(2023, 5, 23, 23, 47, 0, 249, DateTimeKind.Local).AddTicks(3887) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 15, 19, 52, 10, 30, DateTimeKind.Local).AddTicks(7407));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 15, 19, 52, 10, 30, DateTimeKind.Local).AddTicks(7461));

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 15, 19, 52, 10, 30, DateTimeKind.Local).AddTicks(7568), new DateTime(2023, 5, 15, 19, 52, 10, 30, DateTimeKind.Local).AddTicks(7570) });

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 15, 19, 52, 10, 30, DateTimeKind.Local).AddTicks(7574), new DateTime(2023, 5, 15, 19, 52, 10, 30, DateTimeKind.Local).AddTicks(7576) });
        }
    }
}
