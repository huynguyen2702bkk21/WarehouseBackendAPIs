using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase_Configure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryIssueEntries_InventoryIssues_inventoryIssueId",
                table: "InventoryIssueEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceiptEntries_InventoryReceipts_InventoryReceiptId",
                table: "InventoryReceiptEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueLots_InventoryIssueEntries_inventoryIssueEntryId",
                table: "IssueLots");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueSublots_IssueLots_issueLotId",
                table: "IssueSublots");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialClasses_materialClassId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSubLots_MaterialLots_lotNumber",
                table: "MaterialSubLots");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLots_InventoryReceiptEntries_InventoryReceiptEntryId",
                table: "ReceiptLots");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptSublots_ReceiptLots_receiptLotId",
                table: "ReceiptSublots");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryIssueEntries_InventoryIssues_inventoryIssueId",
                table: "InventoryIssueEntries",
                column: "inventoryIssueId",
                principalTable: "InventoryIssues",
                principalColumn: "inventoryIssueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceiptEntries_InventoryReceipts_InventoryReceiptId",
                table: "InventoryReceiptEntries",
                column: "InventoryReceiptId",
                principalTable: "InventoryReceipts",
                principalColumn: "inventoryReceiptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueLots_InventoryIssueEntries_inventoryIssueEntryId",
                table: "IssueLots",
                column: "inventoryIssueEntryId",
                principalTable: "InventoryIssueEntries",
                principalColumn: "inventoryIssueEntryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueSublots_IssueLots_issueLotId",
                table: "IssueSublots",
                column: "issueLotId",
                principalTable: "IssueLots",
                principalColumn: "issueLotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialClasses_materialClassId",
                table: "Materials",
                column: "materialClassId",
                principalTable: "MaterialClasses",
                principalColumn: "materialClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSubLots_MaterialLots_lotNumber",
                table: "MaterialSubLots",
                column: "lotNumber",
                principalTable: "MaterialLots",
                principalColumn: "lotNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLots_InventoryReceiptEntries_InventoryReceiptEntryId",
                table: "ReceiptLots",
                column: "InventoryReceiptEntryId",
                principalTable: "InventoryReceiptEntries",
                principalColumn: "inventoryReceiptEntryId",
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
                name: "FK_InventoryIssueEntries_InventoryIssues_inventoryIssueId",
                table: "InventoryIssueEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceiptEntries_InventoryReceipts_InventoryReceiptId",
                table: "InventoryReceiptEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueLots_InventoryIssueEntries_inventoryIssueEntryId",
                table: "IssueLots");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueSublots_IssueLots_issueLotId",
                table: "IssueSublots");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialClasses_materialClassId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSubLots_MaterialLots_lotNumber",
                table: "MaterialSubLots");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLots_InventoryReceiptEntries_InventoryReceiptEntryId",
                table: "ReceiptLots");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptSublots_ReceiptLots_receiptLotId",
                table: "ReceiptSublots");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryIssueEntries_InventoryIssues_inventoryIssueId",
                table: "InventoryIssueEntries",
                column: "inventoryIssueId",
                principalTable: "InventoryIssues",
                principalColumn: "inventoryIssueId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceiptEntries_InventoryReceipts_InventoryReceiptId",
                table: "InventoryReceiptEntries",
                column: "InventoryReceiptId",
                principalTable: "InventoryReceipts",
                principalColumn: "inventoryReceiptId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueLots_InventoryIssueEntries_inventoryIssueEntryId",
                table: "IssueLots",
                column: "inventoryIssueEntryId",
                principalTable: "InventoryIssueEntries",
                principalColumn: "inventoryIssueEntryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueSublots_IssueLots_issueLotId",
                table: "IssueSublots",
                column: "issueLotId",
                principalTable: "IssueLots",
                principalColumn: "issueLotId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialClasses_materialClassId",
                table: "Materials",
                column: "materialClassId",
                principalTable: "MaterialClasses",
                principalColumn: "materialClassId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSubLots_MaterialLots_lotNumber",
                table: "MaterialSubLots",
                column: "lotNumber",
                principalTable: "MaterialLots",
                principalColumn: "lotNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLots_InventoryReceiptEntries_InventoryReceiptEntryId",
                table: "ReceiptLots",
                column: "InventoryReceiptEntryId",
                principalTable: "InventoryReceiptEntries",
                principalColumn: "inventoryReceiptEntryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptSublots_ReceiptLots_receiptLotId",
                table: "ReceiptSublots",
                column: "receiptLotId",
                principalTable: "ReceiptLots",
                principalColumn: "receiptLotId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
