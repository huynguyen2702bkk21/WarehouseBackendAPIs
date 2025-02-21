using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class CreateStogareArggragateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    warehouseId = table.Column<string>(type: "text", nullable: false),
                    warehouseName = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.warehouseId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    locationId = table.Column<string>(type: "text", nullable: false),
                    warehouseId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.locationId);
                    table.ForeignKey(
                        name: "FK_Locations_Warehouses_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialSubLot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subLotId = table.Column<string>(type: "text", nullable: false),
                    subLotStatus = table.Column<int>(type: "integer", nullable: false),
                    locationId = table.Column<string>(type: "text", nullable: false),
                    existingQuality = table.Column<double>(type: "double precision", nullable: false),
                    unitOfMeasure = table.Column<int>(type: "integer", nullable: false),
                    lotNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSubLot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialSubLot_Locations_locationId",
                        column: x => x.locationId,
                        principalTable: "Locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_warehouseId",
                table: "Locations",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSubLot_locationId",
                table: "MaterialSubLot",
                column: "locationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialSubLot");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
