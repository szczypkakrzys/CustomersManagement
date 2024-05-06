using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomersManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNewAuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeLastModified",
                table: "Customers",
                newName: "TimeLastModifiedInUtc");

            migrationBuilder.RenameColumn(
                name: "TimeCreated",
                table: "Customers",
                newName: "TimeCreatedInUtc");

            migrationBuilder.RenameColumn(
                name: "TimeLastModified",
                table: "Addresses",
                newName: "TimeLastModifiedInUtc");

            migrationBuilder.RenameColumn(
                name: "TimeCreated",
                table: "Addresses",
                newName: "TimeCreatedInUtc");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "EmailAddress", "FirstName", "LastModifiedBy", "LastName" },
                values: new object[] { null, "jwilliams@email.com", "James", null, "Williams" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedBy", "EmailAddress", "FirstName", "LastModifiedBy", "LastName", "TimeCreatedInUtc", "TimeLastModifiedInUtc" },
                values: new object[,]
                {
                    { 2, null, "rjohson@email.com", "Richard", null, "Johson", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, "gsmith@email.com", "George", null, "Smith", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "TimeLastModifiedInUtc",
                table: "Customers",
                newName: "TimeLastModified");

            migrationBuilder.RenameColumn(
                name: "TimeCreatedInUtc",
                table: "Customers",
                newName: "TimeCreated");

            migrationBuilder.RenameColumn(
                name: "TimeLastModifiedInUtc",
                table: "Addresses",
                newName: "TimeLastModified");

            migrationBuilder.RenameColumn(
                name: "TimeCreatedInUtc",
                table: "Addresses",
                newName: "TimeCreated");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "FirstName", "LastName" },
                values: new object[] { "email@email.com", "FirstName", "LastName" });
        }
    }
}
