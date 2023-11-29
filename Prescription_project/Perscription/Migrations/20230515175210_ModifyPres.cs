using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perscription.Migrations
{
    /// <inheritdoc />
    public partial class ModifyPres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perscription_Medicament_Perscriptions_IdPerscription",
                table: "Perscription_Medicament");

            migrationBuilder.RenameColumn(
                name: "IdPerscription",
                table: "Perscriptions",
                newName: "IdPrescription");

            migrationBuilder.RenameColumn(
                name: "IdPerscription",
                table: "Perscription_Medicament",
                newName: "IdPrescription");

            migrationBuilder.RenameIndex(
                name: "IX_Perscription_Medicament_IdPerscription",
                table: "Perscription_Medicament",
                newName: "IX_Perscription_Medicament_IdPrescription");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Perscription_Medicament_Perscriptions_IdPrescription",
                table: "Perscription_Medicament",
                column: "IdPrescription",
                principalTable: "Perscriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perscription_Medicament_Perscriptions_IdPrescription",
                table: "Perscription_Medicament");

            migrationBuilder.RenameColumn(
                name: "IdPrescription",
                table: "Perscriptions",
                newName: "IdPerscription");

            migrationBuilder.RenameColumn(
                name: "IdPrescription",
                table: "Perscription_Medicament",
                newName: "IdPerscription");

            migrationBuilder.RenameIndex(
                name: "IX_Perscription_Medicament_IdPrescription",
                table: "Perscription_Medicament",
                newName: "IX_Perscription_Medicament_IdPerscription");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Perscription_Medicament_Perscriptions_IdPerscription",
                table: "Perscription_Medicament",
                column: "IdPerscription",
                principalTable: "Perscriptions",
                principalColumn: "IdPerscription",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
