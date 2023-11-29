using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perscription.Migrations
{
    /// <inheritdoc />
    public partial class BetterHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "IdUser",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "nrrXEBi7LT/6ADxIiDx/tkwdX3YGfdOwESUakNJeCWI=", "671cd4cb-429c-4e79-9d8e-db5a9e29ae67" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 16, 10, 13, 746, DateTimeKind.Local).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 16, 10, 13, 746, DateTimeKind.Local).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 24, 16, 10, 13, 750, DateTimeKind.Local).AddTicks(8918), new DateTime(2023, 5, 24, 16, 10, 13, 750, DateTimeKind.Local).AddTicks(8925) });

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 24, 16, 10, 13, 750, DateTimeKind.Local).AddTicks(8929), new DateTime(2023, 5, 24, 16, 10, 13, 750, DateTimeKind.Local).AddTicks(8930) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "IdUser",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "fA9OkfqwmJHw9BUK1xvT1BmWBKhEt9cEqX+sQCfi2JI=", "0a9fc25a-9456-4f5d-906d-579c71c3179c" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 16, 1, 59, 130, DateTimeKind.Local).AddTicks(1662));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 16, 1, 59, 130, DateTimeKind.Local).AddTicks(1718));

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 24, 16, 1, 59, 134, DateTimeKind.Local).AddTicks(7664), new DateTime(2023, 5, 24, 16, 1, 59, 134, DateTimeKind.Local).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 24, 16, 1, 59, 134, DateTimeKind.Local).AddTicks(7702), new DateTime(2023, 5, 24, 16, 1, 59, 134, DateTimeKind.Local).AddTicks(7703) });
        }
    }
}
