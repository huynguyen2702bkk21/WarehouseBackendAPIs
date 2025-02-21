using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class Create_EquipmentAggregate_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentClasses",
                columns: table => new
                {
                    equipmentClassId = table.Column<string>(type: "text", nullable: false),
                    className = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentClasses", x => x.equipmentClassId);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentClassProperties",
                columns: table => new
                {
                    propertyId = table.Column<string>(type: "text", nullable: false),
                    propertyName = table.Column<string>(type: "text", nullable: false),
                    propertyValue = table.Column<string>(type: "text", nullable: false),
                    unitOfMeasure = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    equipmentClassId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentClassProperties", x => x.propertyId);
                    table.ForeignKey(
                        name: "FK_EquipmentClassProperties_EquipmentClasses_equipmentClassId",
                        column: x => x.equipmentClassId,
                        principalTable: "EquipmentClasses",
                        principalColumn: "equipmentClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    equipmentId = table.Column<string>(type: "text", nullable: false),
                    equipmentName = table.Column<string>(type: "text", nullable: false),
                    equipmentClassId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.equipmentId);
                    table.ForeignKey(
                        name: "FK_Equipments_EquipmentClasses_equipmentClassId",
                        column: x => x.equipmentClassId,
                        principalTable: "EquipmentClasses",
                        principalColumn: "equipmentClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentProperties",
                columns: table => new
                {
                    propertyId = table.Column<string>(type: "text", nullable: false),
                    propertyName = table.Column<string>(type: "text", nullable: false),
                    propertyValue = table.Column<string>(type: "text", nullable: false),
                    unitOfMeasure = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    equipmentId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentProperties", x => x.propertyId);
                    table.ForeignKey(
                        name: "FK_EquipmentProperties_Equipments_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipments",
                        principalColumn: "equipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentClassProperties_equipmentClassId",
                table: "EquipmentClassProperties",
                column: "equipmentClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentProperties_equipmentId",
                table: "EquipmentProperties",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_equipmentClassId",
                table: "Equipments",
                column: "equipmentClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentClassProperties");

            migrationBuilder.DropTable(
                name: "EquipmentProperties");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "EquipmentClasses");
        }
    }
}
