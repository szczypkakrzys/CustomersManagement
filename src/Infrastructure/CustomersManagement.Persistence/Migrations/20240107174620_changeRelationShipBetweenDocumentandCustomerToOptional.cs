using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomersManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeRelationShipBetweenDocumentandCustomerToOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Clients_Id",
                table: "Document");

            migrationBuilder.AlterColumn<int>(
                name: "ClienId",
                table: "Document",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Clients_Id",
                table: "Document",
                column: "Id",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Clients_Id",
                table: "Document");

            migrationBuilder.AlterColumn<int>(
                name: "ClienId",
                table: "Document",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Clients_Id",
                table: "Document",
                column: "Id",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
