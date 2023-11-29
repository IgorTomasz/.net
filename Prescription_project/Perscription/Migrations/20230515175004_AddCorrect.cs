using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perscription.Migrations
{
    /// <inheritdoc />
    public partial class AddCorrect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 15, 19, 50, 4, 0, DateTimeKind.Local).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 15, 19, 50, 4, 0, DateTimeKind.Local).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPerscription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 15, 19, 50, 4, 0, DateTimeKind.Local).AddTicks(419), new DateTime(2023, 5, 15, 19, 50, 4, 0, DateTimeKind.Local).AddTicks(422) });

            migrationBuilder.UpdateData(
                table: "Perscriptions",
                keyColumn: "IdPerscription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 15, 19, 50, 4, 0, DateTimeKind.Local).AddTicks(426), new DateTime(2023, 5, 15, 19, 50, 4, 0, DateTimeKind.Local).AddTicks(428) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
