using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perscription.Migrations
{
    /// <inheritdoc />
    public partial class SaltRefToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "IdUser",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresAt",
                table: "AppUser",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefToken",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "AppUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "IdUser",
                keyValue: 1,
                columns: new[] { "ExpiresAt", "Password", "RefToken", "Salt" },
                values: new object[] { null, "fA9OkfqwmJHw9BUK1xvT1BmWBKhEt9cEqX+sQCfi2JI=", null, "0a9fc25a-9456-4f5d-906d-579c71c3179c" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiresAt",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "RefToken",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "AppUser");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "AppUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "IdUser",
                keyValue: 1,
                column: "Password",
                value: "123123123");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "IdUser", "Login", "Password" },
                values: new object[] { 2, "Kasia", "Password" });

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
    }
}
