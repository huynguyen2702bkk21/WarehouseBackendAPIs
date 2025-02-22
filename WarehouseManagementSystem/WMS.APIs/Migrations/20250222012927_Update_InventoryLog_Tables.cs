using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class Update_InventoryLog_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLog_MaterialLots_materialLotlotNumber",
                table: "InventoryLog");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLog_Warehouses_warehouseId",
                table: "InventoryLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryLog",
                table: "InventoryLog");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLog_materialLotlotNumber",
                table: "InventoryLog");

            migrationBuilder.DropColumn(
                name: "materialLotlotNumber",
                table: "InventoryLog");

            migrationBuilder.RenameTable(
                name: "InventoryLog",
                newName: "InventoryLogs");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLog_warehouseId",
                table: "InventoryLogs",
                newName: "IX_InventoryLogs_warehouseId");

            migrationBuilder.AlterColumn<string>(
                name: "transactionType",
                table: "InventoryLogs",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryLogs",
                table: "InventoryLogs",
                column: "inventoryLogId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLogs_lotNumber",
                table: "InventoryLogs",
                column: "lotNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogs_MaterialLots_lotNumber",
                table: "InventoryLogs",
                column: "lotNumber",
                principalTable: "MaterialLots",
                principalColumn: "lotNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogs_Warehouses_warehouseId",
                table: "InventoryLogs",
                column: "warehouseId",
                principalTable: "Warehouses",
                principalColumn: "warehouseId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogs_MaterialLots_lotNumber",
                table: "InventoryLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogs_Warehouses_warehouseId",
                table: "InventoryLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryLogs",
                table: "InventoryLogs");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLogs_lotNumber",
                table: "InventoryLogs");

            migrationBuilder.RenameTable(
                name: "InventoryLogs",
                newName: "InventoryLog");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLogs_warehouseId",
                table: "InventoryLog",
                newName: "IX_InventoryLog_warehouseId");

            migrationBuilder.AlterColumn<int>(
                name: "transactionType",
                table: "InventoryLog",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "materialLotlotNumber",
                table: "InventoryLog",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryLog",
                table: "InventoryLog",
                column: "inventoryLogId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLog_materialLotlotNumber",
                table: "InventoryLog",
                column: "materialLotlotNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLog_MaterialLots_materialLotlotNumber",
                table: "InventoryLog",
                column: "materialLotlotNumber",
                principalTable: "MaterialLots",
                principalColumn: "lotNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLog_Warehouses_warehouseId",
                table: "InventoryLog",
                column: "warehouseId",
                principalTable: "Warehouses",
                principalColumn: "warehouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
