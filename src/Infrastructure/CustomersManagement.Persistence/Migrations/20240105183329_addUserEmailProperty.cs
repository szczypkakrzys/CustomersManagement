using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomersManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addUserEmailProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PeselNumber",
                table: "Clients",
                newName: "EmailAddress");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmailAddress",
                value: "email@email.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Clients",
                newName: "PeselNumber");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "PeselNumber",
                value: "");
        }
    }
}
