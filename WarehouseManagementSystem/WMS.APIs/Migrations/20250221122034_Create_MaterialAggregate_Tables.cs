using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class Create_MaterialAggregate_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSubLot_Locations_locationId",
                table: "MaterialSubLot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialSubLot",
                table: "MaterialSubLot");

            migrationBuilder.RenameTable(
                name: "MaterialSubLot",
                newName: "MaterialSubLots");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialSubLot_locationId",
                table: "MaterialSubLots",
                newName: "IX_MaterialSubLots_locationId");

            migrationBuilder.AlterColumn<string>(
                name: "unitOfMeasure",
                table: "MaterialSubLots",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "subLotStatus",
                table: "MaterialSubLots",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MaterialSubLots",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialSubLots",
                table: "MaterialSubLots",
                column: "subLotId");

            migrationBuilder.CreateTable(
                name: "MaterialClasses",
                columns: table => new
                {
                    materialClassId = table.Column<string>(type: "text", nullable: false),
                    className = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialClasses", x => x.materialClassId);
                });

            migrationBuilder.CreateTable(
                name: "MaterialClassProperties",
                columns: table => new
                {
                    propertyId = table.Column<string>(type: "text", nullable: false),
                    propertyName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    propertyValue = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    unitOfMeasure = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    materialClassId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialClassProperties", x => x.propertyId);
                    table.ForeignKey(
                        name: "FK_MaterialClassProperties_MaterialClasses_materialClassId",
                        column: x => x.materialClassId,
                        principalTable: "MaterialClasses",
                        principalColumn: "materialClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    materialId = table.Column<string>(type: "text", nullable: false),
                    materialName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    materialClassId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.materialId);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialClasses_materialClassId",
                        column: x => x.materialClassId,
                        principalTable: "MaterialClasses",
                        principalColumn: "materialClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialLots",
                columns: table => new
                {
                    lotNumber = table.Column<string>(type: "text", nullable: false),
                    lotStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    materialId = table.Column<string>(type: "text", nullable: false),
                    exisitingQuantity = table.Column<double>(type: "double precision", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialLots", x => x.lotNumber);
                    table.ForeignKey(
                        name: "FK_MaterialLots_Materials_materialId",
                        column: x => x.materialId,
                        principalTable: "Materials",
                        principalColumn: "materialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialProperties",
                columns: table => new
                {
                    propertyId = table.Column<string>(type: "text", nullable: false),
                    propertyName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    propertyValue = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    unitOfMeasure = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    materialId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialProperties", x => x.propertyId);
                    table.ForeignKey(
                        name: "FK_MaterialProperties_Materials_materialId",
                        column: x => x.materialId,
                        principalTable: "Materials",
                        principalColumn: "materialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialLotProperties",
                columns: table => new
                {
                    propertyId = table.Column<string>(type: "text", nullable: false),
                    propertyName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    propertyValue = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lotNumber = table.Column<string>(type: "text", nullable: false),
                    unitOfMeasure = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialLotProperties", x => x.propertyId);
                    table.ForeignKey(
                        name: "FK_MaterialLotProperties_MaterialLots_lotNumber",
                        column: x => x.lotNumber,
                        principalTable: "MaterialLots",
                        principalColumn: "lotNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSubLots_lotNumber",
                table: "MaterialSubLots",
                column: "lotNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialClassProperties_materialClassId",
                table: "MaterialClassProperties",
                column: "materialClassId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialLotProperties_lotNumber",
                table: "MaterialLotProperties",
                column: "lotNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialLots_materialId",
                table: "MaterialLots",
                column: "materialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialProperties_materialId",
                table: "MaterialProperties",
                column: "materialId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_materialClassId",
                table: "Materials",
                column: "materialClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSubLots_Locations_locationId",
                table: "MaterialSubLots",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "locationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSubLots_MaterialLots_lotNumber",
                table: "MaterialSubLots",
                column: "lotNumber",
                principalTable: "MaterialLots",
                principalColumn: "lotNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSubLots_Locations_locationId",
                table: "MaterialSubLots");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSubLots_MaterialLots_lotNumber",
                table: "MaterialSubLots");

            migrationBuilder.DropTable(
                name: "MaterialClassProperties");

            migrationBuilder.DropTable(
                name: "MaterialLotProperties");

            migrationBuilder.DropTable(
                name: "MaterialProperties");

            migrationBuilder.DropTable(
                name: "MaterialLots");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "MaterialClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialSubLots",
                table: "MaterialSubLots");

            migrationBuilder.DropIndex(
                name: "IX_MaterialSubLots_lotNumber",
                table: "MaterialSubLots");

            migrationBuilder.RenameTable(
                name: "MaterialSubLots",
                newName: "MaterialSubLot");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialSubLots_locationId",
                table: "MaterialSubLot",
                newName: "IX_MaterialSubLot_locationId");

            migrationBuilder.AlterColumn<int>(
                name: "unitOfMeasure",
                table: "MaterialSubLot",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "subLotStatus",
                table: "MaterialSubLot",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MaterialSubLot",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialSubLot",
                table: "MaterialSubLot",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSubLot_Locations_locationId",
                table: "MaterialSubLot",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "locationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
