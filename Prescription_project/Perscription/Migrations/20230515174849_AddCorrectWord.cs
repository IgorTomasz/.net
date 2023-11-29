using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perscription.Migrations
{
    /// <inheritdoc />
    public partial class AddCorrectWord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 15, 19, 48, 49, 709, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 15, 19, 48, 49, 709, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPerscription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 15, 19, 48, 49, 709, DateTimeKind.Local).AddTicks(8592), new DateTime(2023, 5, 15, 19, 48, 49, 709, DateTimeKind.Local).AddTicks(8594) });

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPerscription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 15, 19, 48, 49, 709, DateTimeKind.Local).AddTicks(8597), new DateTime(2023, 5, 15, 19, 48, 49, 709, DateTimeKind.Local).AddTicks(8599) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 15, 17, 53, 5, 670, DateTimeKind.Local).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 15, 17, 53, 5, 670, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPerscription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 15, 17, 53, 5, 670, DateTimeKind.Local).AddTicks(2083), new DateTime(2023, 5, 15, 17, 53, 5, 670, DateTimeKind.Local).AddTicks(2086) });

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPerscription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 15, 17, 53, 5, 670, DateTimeKind.Local).AddTicks(2091), new DateTime(2023, 5, 15, 17, 53, 5, 670, DateTimeKind.Local).AddTicks(2092) });
        }
    }
}
