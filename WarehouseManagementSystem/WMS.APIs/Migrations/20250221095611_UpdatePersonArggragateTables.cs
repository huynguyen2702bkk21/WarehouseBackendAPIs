using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePersonArggragateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerId = table.Column<string>(type: "text", nullable: false),
                    customerName = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    contactDetails = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    supplierId = table.Column<string>(type: "text", nullable: false),
                    supplierName = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    contactDetails = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.supplierId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
