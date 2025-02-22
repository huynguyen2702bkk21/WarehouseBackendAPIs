using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class Create_InventoryLog_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryLog",
                columns: table => new
                {
                    inventoryLogId = table.Column<string>(type: "text", nullable: false),
                    transactionType = table.Column<int>(type: "integer", nullable: false),
                    transactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    previousQuantity = table.Column<double>(type: "double precision", nullable: false),
                    changedQuantity = table.Column<double>(type: "double precision", nullable: false),
                    afterQuantity = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: false),
                    lotNumber = table.Column<string>(type: "text", nullable: false),
                    materialLotlotNumber = table.Column<string>(type: "text", nullable: true),
                    warehouseId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLog", x => x.inventoryLogId);
                    table.ForeignKey(
                        name: "FK_InventoryLog_MaterialLots_materialLotlotNumber",
                        column: x => x.materialLotlotNumber,
                        principalTable: "MaterialLots",
                        principalColumn: "lotNumber");
                    table.ForeignKey(
                        name: "FK_InventoryLog_Warehouses_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLog_materialLotlotNumber",
                table: "InventoryLog",
                column: "materialLotlotNumber");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLog_warehouseId",
                table: "InventoryLog",
                column: "warehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryLog");
        }
    }
}
