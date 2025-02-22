using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class Create_MaterialLotAdjustment_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialLotAdjustments",
                columns: table => new
                {
                    materialLotAdjustmentId = table.Column<string>(type: "text", nullable: false),
                    adjustmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    previousQuantity = table.Column<double>(type: "double precision", nullable: false),
                    adjustedQuantity = table.Column<double>(type: "double precision", nullable: false),
                    reason = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    note = table.Column<string>(type: "text", nullable: false),
                    lotNumber = table.Column<string>(type: "text", nullable: false),
                    warehouseId = table.Column<string>(type: "text", nullable: false),
                    employeeId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialLotAdjustments", x => x.materialLotAdjustmentId);
                    table.ForeignKey(
                        name: "FK_MaterialLotAdjustments_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialLotAdjustments_MaterialLots_lotNumber",
                        column: x => x.lotNumber,
                        principalTable: "MaterialLots",
                        principalColumn: "lotNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialLotAdjustments_Warehouses_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialLotAdjustments_employeeId",
                table: "MaterialLotAdjustments",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialLotAdjustments_lotNumber",
                table: "MaterialLotAdjustments",
                column: "lotNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialLotAdjustments_warehouseId",
                table: "MaterialLotAdjustments",
                column: "warehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialLotAdjustments");
        }
    }
}
