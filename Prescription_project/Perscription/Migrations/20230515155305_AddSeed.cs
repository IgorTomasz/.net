using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Perscription.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerscriptionMedicaments_Medicaments_IdMedicament",
                table: "PerscriptionMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_PerscriptionMedicaments_Perscriptions_IdPerscription",
                table: "PerscriptionMedicaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerscriptionMedicaments",
                table: "PerscriptionMedicaments");

            migrationBuilder.RenameTable(
                name: "PerscriptionMedicaments",
                newName: "Perscription_Medicament");

            migrationBuilder.RenameIndex(
                name: "IX_PerscriptionMedicaments_IdPerscription",
                table: "Perscription_Medicament",
                newName: "IX_Perscription_Medicament_IdPerscription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Perscription_Medicament",
                table: "Perscription_Medicament",
                columns: new[] { "IdMedicament", "IdPerscription" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "d.bab@gmail.com", "Dominik", "Babacki" },
                    { 2, "e.jan@gmail.com", "Emil", "Janacki" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Lek przeciwbólowy", "Aspiryna", "Przeciwbólowy" },
                    { 2, "Używać zgodnie z zaleceniami lekarza", "Zyrtec", "Przeciwalergiczny" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 17, 53, 5, 670, DateTimeKind.Local).AddTicks(1849), "Adam", "Kowalski" },
                    { 2, new DateTime(2023, 5, 15, 17, 53, 5, 670, DateTimeKind.Local).AddTicks(1903), "Jan", "Kabacki" }
                });

            migrationBuilder.InsertData(
                table: "Perscriptions",
                columns: new[] { "IdPerscription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 17, 53, 5, 670, DateTimeKind.Local).AddTicks(2083), new DateTime(2023, 5, 15, 17, 53, 5, 670, DateTimeKind.Local).AddTicks(2086), 2, 1 },
                    { 2, new DateTime(2023, 5, 15, 17, 53, 5, 670, DateTimeKind.Local).AddTicks(2091), new DateTime(2023, 5, 15, 17, 53, 5, 670, DateTimeKind.Local).AddTicks(2092), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Perscription_Medicament",
                columns: new[] { "IdMedicament", "IdPerscription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 2, "Stosować przez 2 tygodnie", null },
                    { 2, 1, "Dwa razy dziennie, jedna tabletka", 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Perscription_Medicament_Medicaments_IdMedicament",
                table: "Perscription_Medicament",
                column: "IdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Perscription_Medicament_Perscriptions_IdPerscription",
                table: "Perscription_Medicament",
                column: "IdPerscription",
                principalTable: "Perscriptions",
                principalColumn: "IdPerscription",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perscription_Medicament_Medicaments_IdMedicament",
                table: "Perscription_Medicament");

            migrationBuilder.DropForeignKey(
                name: "FK_Perscription_Medicament_Perscriptions_IdPerscription",
                table: "Perscription_Medicament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Perscription_Medicament",
                table: "Perscription_Medicament");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Perscription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPerscription" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Perscription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPerscription" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Perscriptions",
                keyColumn: "IdPerscription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Perscriptions",
                keyColumn: "IdPerscription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Perscription_Medicament",
                newName: "PerscriptionMedicaments");

            migrationBuilder.RenameIndex(
                name: "IX_Perscription_Medicament_IdPerscription",
                table: "PerscriptionMedicaments",
                newName: "IX_PerscriptionMedicaments_IdPerscription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerscriptionMedicaments",
                table: "PerscriptionMedicaments",
                columns: new[] { "IdMedicament", "IdPerscription" });

            migrationBuilder.AddForeignKey(
                name: "FK_PerscriptionMedicaments_Medicaments_IdMedicament",
                table: "PerscriptionMedicaments",
                column: "IdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerscriptionMedicaments_Perscriptions_IdPerscription",
                table: "PerscriptionMedicaments",
                column: "IdPerscription",
                principalTable: "Perscriptions",
                principalColumn: "IdPerscription",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
