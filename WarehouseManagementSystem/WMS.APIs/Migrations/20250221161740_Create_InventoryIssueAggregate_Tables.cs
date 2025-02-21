using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class Create_InventoryIssueAggregate_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceipt_Employees_employeeId",
                table: "InventoryReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceipt_Suppliers_supplierId",
                table: "InventoryReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceipt_Warehouses_warehouseId",
                table: "InventoryReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceiptEntry_InventoryReceipt_InventoryReceiptId",
                table: "InventoryReceiptEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLot_InventoryReceiptEntry_InventoryReceiptEntryId",
                table: "ReceiptLot");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLot_Materials_materialId",
                table: "ReceiptLot");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptSublot_Locations_locationId",
                table: "ReceiptSublot");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptSublot_ReceiptLot_receiptLotId",
                table: "ReceiptSublot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptSublot",
                table: "ReceiptSublot");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptSublot_receiptLotId",
                table: "ReceiptSublot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptLot",
                table: "ReceiptLot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryReceiptEntry",
                table: "InventoryReceiptEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryReceipt",
                table: "InventoryReceipt");

            migrationBuilder.RenameTable(
                name: "ReceiptSublot",
                newName: "ReceiptSublots");

            migrationBuilder.RenameTable(
                name: "ReceiptLot",
                newName: "ReceiptLots");

            migrationBuilder.RenameTable(
                name: "InventoryReceiptEntry",
                newName: "InventoryReceiptEntries");

            migrationBuilder.RenameTable(
                name: "InventoryReceipt",
                newName: "InventoryReceipts");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptSublot_locationId",
                table: "ReceiptSublots",
                newName: "IX_ReceiptSublots_locationId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptLot_materialId",
                table: "ReceiptLots",
                newName: "IX_ReceiptLots_materialId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptLot_InventoryReceiptEntryId",
                table: "ReceiptLots",
                newName: "IX_ReceiptLots_InventoryReceiptEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryReceiptEntry_InventoryReceiptId",
                table: "InventoryReceiptEntries",
                newName: "IX_InventoryReceiptEntries_InventoryReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryReceipt_warehouseId",
                table: "InventoryReceipts",
                newName: "IX_InventoryReceipts_warehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryReceipt_supplierId",
                table: "InventoryReceipts",
                newName: "IX_InventoryReceipts_supplierId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryReceipt_employeeId",
                table: "InventoryReceipts",
                newName: "IX_InventoryReceipts_employeeId");

            migrationBuilder.AlterColumn<string>(
                name: "unitOfMeasure",
                table: "ReceiptSublots",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "subLotStatus",
                table: "ReceiptSublots",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "receiptSublotId",
                table: "ReceiptSublots",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "lotStatus",
                table: "ReceiptLots",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "InventoryReceiptEntries",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "receiptStatus",
                table: "InventoryReceipts",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptSublots",
                table: "ReceiptSublots",
                column: "receiptLotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptLots",
                table: "ReceiptLots",
                column: "receiptLotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryReceiptEntries",
                table: "InventoryReceiptEntries",
                column: "inventoryReceiptEntryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryReceipts",
                table: "InventoryReceipts",
                column: "inventoryReceiptId");

            migrationBuilder.CreateTable(
                name: "InventoryIssues",
                columns: table => new
                {
                    inventoryIssueId = table.Column<string>(type: "text", nullable: false),
                    issueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    issueStatus = table.Column<string>(type: "text", nullable: false),
                    customerId = table.Column<string>(type: "text", nullable: false),
                    employeeId = table.Column<string>(type: "text", nullable: false),
                    warehouseId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryIssues", x => x.inventoryIssueId);
                    table.ForeignKey(
                        name: "FK_InventoryIssues_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryIssues_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryIssues_Warehouses_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryIssueEntries",
                columns: table => new
                {
                    inventoryIssueEntryId = table.Column<string>(type: "text", nullable: false),
                    purchaseOrderNumber = table.Column<string>(type: "text", nullable: false),
                    requestedQuantity = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    issueLotId = table.Column<string>(type: "text", nullable: false),
                    inventoryIssueId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryIssueEntries", x => x.inventoryIssueEntryId);
                    table.ForeignKey(
                        name: "FK_InventoryIssueEntries_InventoryIssues_inventoryIssueId",
                        column: x => x.inventoryIssueId,
                        principalTable: "InventoryIssues",
                        principalColumn: "inventoryIssueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueLots",
                columns: table => new
                {
                    issueLotId = table.Column<string>(type: "text", nullable: false),
                    requestedQuantity = table.Column<double>(type: "double precision", nullable: false),
                    lotStatus = table.Column<string>(type: "text", nullable: false),
                    materialId = table.Column<string>(type: "text", nullable: false),
                    inventoryIssueEntryId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueLots", x => x.issueLotId);
                    table.ForeignKey(
                        name: "FK_IssueLots_InventoryIssueEntries_inventoryIssueEntryId",
                        column: x => x.inventoryIssueEntryId,
                        principalTable: "InventoryIssueEntries",
                        principalColumn: "inventoryIssueEntryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueLots_Materials_materialId",
                        column: x => x.materialId,
                        principalTable: "Materials",
                        principalColumn: "materialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueSublots",
                columns: table => new
                {
                    issueSublotId = table.Column<string>(type: "text", nullable: false),
                    requestedQuantity = table.Column<double>(type: "double precision", nullable: false),
                    subLotStatus = table.Column<string>(type: "text", nullable: false),
                    unitOfMeasure = table.Column<string>(type: "text", nullable: false),
                    locationId = table.Column<string>(type: "text", nullable: false),
                    issueLotId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueSublots", x => x.issueSublotId);
                    table.ForeignKey(
                        name: "FK_IssueSublots_IssueLots_issueLotId",
                        column: x => x.issueLotId,
                        principalTable: "IssueLots",
                        principalColumn: "issueLotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueSublots_Locations_locationId",
                        column: x => x.locationId,
                        principalTable: "Locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssueEntries_inventoryIssueId",
                table: "InventoryIssueEntries",
                column: "inventoryIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssues_customerId",
                table: "InventoryIssues",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssues_employeeId",
                table: "InventoryIssues",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssues_warehouseId",
                table: "InventoryIssues",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueLots_inventoryIssueEntryId",
                table: "IssueLots",
                column: "inventoryIssueEntryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueLots_materialId",
                table: "IssueLots",
                column: "materialId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueSublots_issueLotId",
                table: "IssueSublots",
                column: "issueLotId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueSublots_locationId",
                table: "IssueSublots",
                column: "locationId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceiptEntries_InventoryReceipts_InventoryReceiptId",
                table: "InventoryReceiptEntries",
                column: "InventoryReceiptId",
                principalTable: "InventoryReceipts",
                principalColumn: "inventoryReceiptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceipts_Employees_employeeId",
                table: "InventoryReceipts",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "employeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceipts_Suppliers_supplierId",
                table: "InventoryReceipts",
                column: "supplierId",
                principalTable: "Suppliers",
                principalColumn: "supplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceipts_Warehouses_warehouseId",
                table: "InventoryReceipts",
                column: "warehouseId",
                principalTable: "Warehouses",
                principalColumn: "warehouseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLots_InventoryReceiptEntries_InventoryReceiptEntryId",
                table: "ReceiptLots",
                column: "InventoryReceiptEntryId",
                principalTable: "InventoryReceiptEntries",
                principalColumn: "inventoryReceiptEntryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLots_Materials_materialId",
                table: "ReceiptLots",
                column: "materialId",
                principalTable: "Materials",
                principalColumn: "materialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptSublots_Locations_locationId",
                table: "ReceiptSublots",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "locationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptSublots_ReceiptLots_receiptLotId",
                table: "ReceiptSublots",
                column: "receiptLotId",
                principalTable: "ReceiptLots",
                principalColumn: "receiptLotId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceiptEntries_InventoryReceipts_InventoryReceiptId",
                table: "InventoryReceiptEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceipts_Employees_employeeId",
                table: "InventoryReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceipts_Suppliers_supplierId",
                table: "InventoryReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceipts_Warehouses_warehouseId",
                table: "InventoryReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLots_InventoryReceiptEntries_InventoryReceiptEntryId",
                table: "ReceiptLots");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLots_Materials_materialId",
                table: "ReceiptLots");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptSublots_Locations_locationId",
                table: "ReceiptSublots");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptSublots_ReceiptLots_receiptLotId",
                table: "ReceiptSublots");

            migrationBuilder.DropTable(
                name: "IssueSublots");

            migrationBuilder.DropTable(
                name: "IssueLots");

            migrationBuilder.DropTable(
                name: "InventoryIssueEntries");

            migrationBuilder.DropTable(
                name: "InventoryIssues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptSublots",
                table: "ReceiptSublots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptLots",
                table: "ReceiptLots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryReceipts",
                table: "InventoryReceipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryReceiptEntries",
                table: "InventoryReceiptEntries");

            migrationBuilder.RenameTable(
                name: "ReceiptSublots",
                newName: "ReceiptSublot");

            migrationBuilder.RenameTable(
                name: "ReceiptLots",
                newName: "ReceiptLot");

            migrationBuilder.RenameTable(
                name: "InventoryReceipts",
                newName: "InventoryReceipt");

            migrationBuilder.RenameTable(
                name: "InventoryReceiptEntries",
                newName: "InventoryReceiptEntry");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptSublots_locationId",
                table: "ReceiptSublot",
                newName: "IX_ReceiptSublot_locationId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptLots_materialId",
                table: "ReceiptLot",
                newName: "IX_ReceiptLot_materialId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptLots_InventoryReceiptEntryId",
                table: "ReceiptLot",
                newName: "IX_ReceiptLot_InventoryReceiptEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryReceipts_warehouseId",
                table: "InventoryReceipt",
                newName: "IX_InventoryReceipt_warehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryReceipts_supplierId",
                table: "InventoryReceipt",
                newName: "IX_InventoryReceipt_supplierId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryReceipts_employeeId",
                table: "InventoryReceipt",
                newName: "IX_InventoryReceipt_employeeId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryReceiptEntries_InventoryReceiptId",
                table: "InventoryReceiptEntry",
                newName: "IX_InventoryReceiptEntry_InventoryReceiptId");

            migrationBuilder.AlterColumn<int>(
                name: "unitOfMeasure",
                table: "ReceiptSublot",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "subLotStatus",
                table: "ReceiptSublot",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "receiptSublotId",
                table: "ReceiptSublot",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "lotStatus",
                table: "ReceiptLot",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "receiptStatus",
                table: "InventoryReceipt",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "InventoryReceiptEntry",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptSublot",
                table: "ReceiptSublot",
                column: "receiptSublotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptLot",
                table: "ReceiptLot",
                column: "receiptLotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryReceipt",
                table: "InventoryReceipt",
                column: "inventoryReceiptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryReceiptEntry",
                table: "InventoryReceiptEntry",
                column: "inventoryReceiptEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptSublot_receiptLotId",
                table: "ReceiptSublot",
                column: "receiptLotId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceipt_Employees_employeeId",
                table: "InventoryReceipt",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "employeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceipt_Suppliers_supplierId",
                table: "InventoryReceipt",
                column: "supplierId",
                principalTable: "Suppliers",
                principalColumn: "supplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceipt_Warehouses_warehouseId",
                table: "InventoryReceipt",
                column: "warehouseId",
                principalTable: "Warehouses",
                principalColumn: "warehouseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceiptEntry_InventoryReceipt_InventoryReceiptId",
                table: "InventoryReceiptEntry",
                column: "InventoryReceiptId",
                principalTable: "InventoryReceipt",
                principalColumn: "inventoryReceiptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLot_InventoryReceiptEntry_InventoryReceiptEntryId",
                table: "ReceiptLot",
                column: "InventoryReceiptEntryId",
                principalTable: "InventoryReceiptEntry",
                principalColumn: "inventoryReceiptEntryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLot_Materials_materialId",
                table: "ReceiptLot",
                column: "materialId",
                principalTable: "Materials",
                principalColumn: "materialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptSublot_Locations_locationId",
                table: "ReceiptSublot",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "locationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptSublot_ReceiptLot_receiptLotId",
                table: "ReceiptSublot",
                column: "receiptLotId",
                principalTable: "ReceiptLot",
                principalColumn: "receiptLotId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
