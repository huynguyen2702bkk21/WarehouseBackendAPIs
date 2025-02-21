using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class Create_InventoryReceiptAggregate_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryReceipt",
                columns: table => new
                {
                    inventoryReceiptId = table.Column<string>(type: "text", nullable: false),
                    receiptDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    receiptStatus = table.Column<int>(type: "integer", nullable: false),
                    supplierId = table.Column<string>(type: "text", nullable: false),
                    employeeId = table.Column<string>(type: "text", nullable: false),
                    warehouseId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryReceipt", x => x.inventoryReceiptId);
                    table.ForeignKey(
                        name: "FK_InventoryReceipt_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryReceipt_Suppliers_supplierId",
                        column: x => x.supplierId,
                        principalTable: "Suppliers",
                        principalColumn: "supplierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryReceipt_Warehouses_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryReceiptEntry",
                columns: table => new
                {
                    inventoryReceiptEntryId = table.Column<string>(type: "text", nullable: false),
                    purchaseOrderNumber = table.Column<string>(type: "text", nullable: false),
                    note = table.Column<string>(type: "text", nullable: false),
                    lotNumber = table.Column<string>(type: "text", nullable: false),
                    InventoryReceiptId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryReceiptEntry", x => x.inventoryReceiptEntryId);
                    table.ForeignKey(
                        name: "FK_InventoryReceiptEntry_InventoryReceipt_InventoryReceiptId",
                        column: x => x.InventoryReceiptId,
                        principalTable: "InventoryReceipt",
                        principalColumn: "inventoryReceiptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptLot",
                columns: table => new
                {
                    receiptLotId = table.Column<string>(type: "text", nullable: false),
                    importedQuantity = table.Column<double>(type: "double precision", nullable: false),
                    lotStatus = table.Column<int>(type: "integer", nullable: false),
                    materialId = table.Column<string>(type: "text", nullable: false),
                    InventoryReceiptEntryId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptLot", x => x.receiptLotId);
                    table.ForeignKey(
                        name: "FK_ReceiptLot_InventoryReceiptEntry_InventoryReceiptEntryId",
                        column: x => x.InventoryReceiptEntryId,
                        principalTable: "InventoryReceiptEntry",
                        principalColumn: "inventoryReceiptEntryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptLot_Materials_materialId",
                        column: x => x.materialId,
                        principalTable: "Materials",
                        principalColumn: "materialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptSublot",
                columns: table => new
                {
                    receiptSublotId = table.Column<string>(type: "text", nullable: false),
                    importedQuantity = table.Column<double>(type: "double precision", nullable: false),
                    subLotStatus = table.Column<int>(type: "integer", nullable: false),
                    unitOfMeasure = table.Column<int>(type: "integer", nullable: false),
                    locationId = table.Column<string>(type: "text", nullable: false),
                    receiptLotId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptSublot", x => x.receiptSublotId);
                    table.ForeignKey(
                        name: "FK_ReceiptSublot_Locations_locationId",
                        column: x => x.locationId,
                        principalTable: "Locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptSublot_ReceiptLot_receiptLotId",
                        column: x => x.receiptLotId,
                        principalTable: "ReceiptLot",
                        principalColumn: "receiptLotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceipt_employeeId",
                table: "InventoryReceipt",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceipt_supplierId",
                table: "InventoryReceipt",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceipt_warehouseId",
                table: "InventoryReceipt",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceiptEntry_InventoryReceiptId",
                table: "InventoryReceiptEntry",
                column: "InventoryReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptLot_InventoryReceiptEntryId",
                table: "ReceiptLot",
                column: "InventoryReceiptEntryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptLot_materialId",
                table: "ReceiptLot",
                column: "materialId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptSublot_locationId",
                table: "ReceiptSublot",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptSublot_receiptLotId",
                table: "ReceiptSublot",
                column: "receiptLotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiptSublot");

            migrationBuilder.DropTable(
                name: "ReceiptLot");

            migrationBuilder.DropTable(
                name: "InventoryReceiptEntry");

            migrationBuilder.DropTable(
                name: "InventoryReceipt");
        }
    }
}
