using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class Update_InventoryEntry_IssueAndReceipt_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueLots_Materials_materialId",
                table: "IssueLots");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLots_Materials_materialId",
                table: "ReceiptLots");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptLots_materialId",
                table: "ReceiptLots");

            migrationBuilder.DropIndex(
                name: "IX_IssueLots_materialId",
                table: "IssueLots");

            migrationBuilder.DropColumn(
                name: "materialId",
                table: "ReceiptLots");

            migrationBuilder.DropColumn(
                name: "materialId",
                table: "IssueLots");

            migrationBuilder.AddColumn<string>(
                name: "materialId",
                table: "InventoryReceiptEntries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "materialId",
                table: "InventoryIssueEntries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceiptEntries_materialId",
                table: "InventoryReceiptEntries",
                column: "materialId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssueEntries_materialId",
                table: "InventoryIssueEntries",
                column: "materialId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryIssueEntries_Materials_materialId",
                table: "InventoryIssueEntries",
                column: "materialId",
                principalTable: "Materials",
                principalColumn: "materialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceiptEntries_Materials_materialId",
                table: "InventoryReceiptEntries",
                column: "materialId",
                principalTable: "Materials",
                principalColumn: "materialId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryIssueEntries_Materials_materialId",
                table: "InventoryIssueEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceiptEntries_Materials_materialId",
                table: "InventoryReceiptEntries");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceiptEntries_materialId",
                table: "InventoryReceiptEntries");

            migrationBuilder.DropIndex(
                name: "IX_InventoryIssueEntries_materialId",
                table: "InventoryIssueEntries");

            migrationBuilder.DropColumn(
                name: "materialId",
                table: "InventoryReceiptEntries");

            migrationBuilder.DropColumn(
                name: "materialId",
                table: "InventoryIssueEntries");

            migrationBuilder.AddColumn<string>(
                name: "materialId",
                table: "ReceiptLots",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "materialId",
                table: "IssueLots",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptLots_materialId",
                table: "ReceiptLots",
                column: "materialId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueLots_materialId",
                table: "IssueLots",
                column: "materialId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueLots_Materials_materialId",
                table: "IssueLots",
                column: "materialId",
                principalTable: "Materials",
                principalColumn: "materialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLots_Materials_materialId",
                table: "ReceiptLots",
                column: "materialId",
                principalTable: "Materials",
                principalColumn: "materialId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
