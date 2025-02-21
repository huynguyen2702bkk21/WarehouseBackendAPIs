using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Employees");

            migrationBuilder.RenameColumn(
                name: "personName",
                table: "Employees",
                newName: "employeeName");

            migrationBuilder.RenameColumn(
                name: "personId",
                table: "Employees",
                newName: "employeeId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "employeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Persons");

            migrationBuilder.RenameColumn(
                name: "employeeName",
                table: "Persons",
                newName: "personName");

            migrationBuilder.RenameColumn(
                name: "employeeId",
                table: "Persons",
                newName: "personId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "personId");
        }
    }
}
