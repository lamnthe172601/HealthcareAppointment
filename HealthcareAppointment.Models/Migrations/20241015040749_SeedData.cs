using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthcareAppointment.Models.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
             table: "User",
             columns: new[] { "Id", "Name", "Email", "DateOfBirth", "Password", "Role", "Specialization" },
             values: new object[,]
             {
                { "1", "Dr. John Doe", "john.doe@example.com", new DateTime(1980, 1, 1), "password123", 0, "Cardiology" },
                { "2", "Dr. Jane Smith", "jane.smith@example.com", new DateTime(1985, 5, 15), "password456", 0, "Pediatrics" },
                { "3", "Alice Johnson", "alice.johnson@example.com", new DateTime(1990, 10, 20), "password789", 1, "Patient" },
                { "4", "Bob Williams", "bob.williams@example.com", new DateTime(1975, 3, 30), "passwordabc", 1, "Patient" },
                { "5", "Emma Brown", "emma.brown@example.com", new DateTime(1995, 7, 7), "passworddef", 1, "Patient" }
             });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "DoctorId", "PatientId", "Date", "Status" },
                values: new object[,]
                {
                { "1", "1", "3", DateTime.Now.AddDays(1), 0 },
                { "2", "2", "4", DateTime.Now.AddDays(2), 0 },
                { "3", "1", "5", DateTime.Now.AddDays(3), 0 },
                { "4", "2", "3", DateTime.Now.AddDays(4), 0 },
                { "5", "1", "4", DateTime.Now.AddDays(5), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "Appointment",
            keyColumn: "Id",
            keyValues: new object[] { "1", "2", "3", "4", "5" });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValues: new object[] { "1", "2", "3", "4", "5" });
        }
    }
}
