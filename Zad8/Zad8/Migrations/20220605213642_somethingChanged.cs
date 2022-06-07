using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zad8.Migrations
{
    public partial class somethingChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Prescription_Medicaments",
                newName: "Details");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "henderson@doctor.com", "Angel", "Henderson" },
                    { 2, "bridgetcurtis@doctor.com", "Bridget", "Curtis" },
                    { 3, "michaelsilva@doctor.com", "Michael", "Silva" },
                    { 4, "jenniferwilson@doctor.com", "Jennifer", "Wilson" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMecicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Lek na ból głowy", "Apap", "Tabletki" },
                    { 2, "Syrop na kaszel", "Flegamina", "Syrop" },
                    { 3, "Na skarzenia radioaktywne", "Płyn Lugola", "Syrop" },
                    { 4, "Maść na ból stawów", "Voltaren", "Maść" },
                    { 5, "Lek przeciwbólowy", "Ibuprom", "Tabletki" },
                    { 6, "Lek na ból brzucha", "Nospa", "Tabletki" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1992, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul", "Rodriguez" },
                    { 2, new DateTime(1985, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eric", "Gomez" },
                    { 3, new DateTime(1989, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julie", "Robertson" },
                    { 4, new DateTime(1989, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tracy", "Kelly" },
                    { 5, new DateTime(1984, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordan", "Green" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 2, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 3, new DateTime(2022, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMecicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "W przypadku gorączki powyżej 40 stopni", 2 },
                    { 2, 1, "Najpóźniej o 18", 3 },
                    { 4, 2, "Bezpośrednio po treningu", 3 },
                    { 6, 3, "W przypadku silnego bólu brzucha", 2 },
                    { 5, 3, "W przypadku wystąpienia bólu głowy", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMecicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMecicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMecicament", "IdPrescription" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMecicament", "IdPrescription" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMecicament", "IdPrescription" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMecicament", "IdPrescription" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMecicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMecicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMecicament",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMecicament",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMecicament",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

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
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Prescription_Medicaments",
                newName: "Description");
        }
    }
}
