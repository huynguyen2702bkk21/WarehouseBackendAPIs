using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class CreateSQLDAtabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contactDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentClasses",
                columns: table => new
                {
                    equipmentClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    className = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentClasses", x => x.equipmentClassId);
                });

            migrationBuilder.CreateTable(
                name: "MaterialClasses",
                columns: table => new
                {
                    materialClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    className = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialClasses", x => x.materialClassId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    personId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    personName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.personId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    supplierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    supplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contactDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.supplierId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    warehouseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    warehouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.warehouseId);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentClassProperties",
                columns: table => new
                {
                    propertyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    propertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    equipmentClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentClassProperties", x => x.propertyId);
                    table.ForeignKey(
                        name: "FK_EquipmentClassProperties_EquipmentClasses_equipmentClassId",
                        column: x => x.equipmentClassId,
                        principalTable: "EquipmentClasses",
                        principalColumn: "equipmentClassId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    equipmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    equipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    equipmentClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.equipmentId);
                    table.ForeignKey(
                        name: "FK_Equipments_EquipmentClasses_equipmentClassId",
                        column: x => x.equipmentClassId,
                        principalTable: "EquipmentClasses",
                        principalColumn: "equipmentClassId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialClassProperties",
                columns: table => new
                {
                    propertyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    propertyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    propertyValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    unitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    materialClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialClassProperties", x => x.propertyId);
                    table.ForeignKey(
                        name: "FK_MaterialClassProperties_MaterialClasses_materialClassId",
                        column: x => x.materialClassId,
                        principalTable: "MaterialClasses",
                        principalColumn: "materialClassId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    materialId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    materialName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    materialClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.materialId);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialClasses_materialClassId",
                        column: x => x.materialClassId,
                        principalTable: "MaterialClasses",
                        principalColumn: "materialClassId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryIssues",
                columns: table => new
                {
                    inventoryIssueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    issueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    issueStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    pesonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    warehouseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryIssues", x => x.inventoryIssueId);
                    table.ForeignKey(
                        name: "FK_InventoryIssues_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryIssues_Persons_pesonId",
                        column: x => x.pesonId,
                        principalTable: "Persons",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryIssues_Warehouses_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryReceipts",
                columns: table => new
                {
                    inventoryReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    receiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    receiptStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    personId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    warehouseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryReceipts", x => x.inventoryReceiptId);
                    table.ForeignKey(
                        name: "FK_InventoryReceipts_Persons_personId",
                        column: x => x.personId,
                        principalTable: "Persons",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryReceipts_Suppliers_supplierId",
                        column: x => x.supplierId,
                        principalTable: "Suppliers",
                        principalColumn: "supplierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryReceipts_Warehouses_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    locationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    warehouseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.locationId);
                    table.ForeignKey(
                        name: "FK_Locations_Warehouses_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentProperties",
                columns: table => new
                {
                    propertyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    propertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    equipmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentProperties", x => x.propertyId);
                    table.ForeignKey(
                        name: "FK_EquipmentProperties_Equipments_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipments",
                        principalColumn: "equipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialLots",
                columns: table => new
                {
                    lotNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lotStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    materialId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    exisitingQuantity = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialLots", x => x.lotNumber);
                    table.ForeignKey(
                        name: "FK_MaterialLots_Materials_materialId",
                        column: x => x.materialId,
                        principalTable: "Materials",
                        principalColumn: "materialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialProperties",
                columns: table => new
                {
                    propertyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    propertyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    propertyValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    unitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    materialId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialProperties", x => x.propertyId);
                    table.ForeignKey(
                        name: "FK_MaterialProperties_Materials_materialId",
                        column: x => x.materialId,
                        principalTable: "Materials",
                        principalColumn: "materialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryIssueEntries",
                columns: table => new
                {
                    inventoryIssueEntryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    purchaseOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requestedQuantity = table.Column<double>(type: "float", nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    materialId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    issueLotId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inventoryIssueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryIssueEntries", x => x.inventoryIssueEntryId);
                    table.ForeignKey(
                        name: "FK_InventoryIssueEntries_InventoryIssues_inventoryIssueId",
                        column: x => x.inventoryIssueId,
                        principalTable: "InventoryIssues",
                        principalColumn: "inventoryIssueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryIssueEntries_Materials_materialId",
                        column: x => x.materialId,
                        principalTable: "Materials",
                        principalColumn: "materialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryReceiptEntries",
                columns: table => new
                {
                    inventoryReceiptEntryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    purchaseOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    materialId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    lotNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryReceiptEntries", x => x.inventoryReceiptEntryId);
                    table.ForeignKey(
                        name: "FK_InventoryReceiptEntries_InventoryReceipts_InventoryReceiptId",
                        column: x => x.InventoryReceiptId,
                        principalTable: "InventoryReceipts",
                        principalColumn: "inventoryReceiptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryReceiptEntries_Materials_materialId",
                        column: x => x.materialId,
                        principalTable: "Materials",
                        principalColumn: "materialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryLogs",
                columns: table => new
                {
                    inventoryLogId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    transactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    previousQuantity = table.Column<double>(type: "float", nullable: false),
                    changedQuantity = table.Column<double>(type: "float", nullable: false),
                    afterQuantity = table.Column<double>(type: "float", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lotNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    warehouseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLogs", x => x.inventoryLogId);
                    table.ForeignKey(
                        name: "FK_InventoryLogs_MaterialLots_lotNumber",
                        column: x => x.lotNumber,
                        principalTable: "MaterialLots",
                        principalColumn: "lotNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryLogs_Warehouses_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialLotAdjustments",
                columns: table => new
                {
                    materialLotAdjustmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    adjustmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    previousQuantity = table.Column<double>(type: "float", nullable: false),
                    adjustedQuantity = table.Column<double>(type: "float", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lotNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    warehouseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    personId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialLotAdjustments", x => x.materialLotAdjustmentId);
                    table.ForeignKey(
                        name: "FK_MaterialLotAdjustments_MaterialLots_lotNumber",
                        column: x => x.lotNumber,
                        principalTable: "MaterialLots",
                        principalColumn: "lotNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialLotAdjustments_Persons_personId",
                        column: x => x.personId,
                        principalTable: "Persons",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialLotAdjustments_Warehouses_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialLotProperties",
                columns: table => new
                {
                    propertyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    propertyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    propertyValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lotNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    unitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialLotProperties", x => x.propertyId);
                    table.ForeignKey(
                        name: "FK_MaterialLotProperties_MaterialLots_lotNumber",
                        column: x => x.lotNumber,
                        principalTable: "MaterialLots",
                        principalColumn: "lotNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialSubLots",
                columns: table => new
                {
                    subLotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    subLotStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    existingQuality = table.Column<double>(type: "float", nullable: false),
                    unitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    locationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lotNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSubLots", x => x.subLotId);
                    table.ForeignKey(
                        name: "FK_MaterialSubLots_Locations_locationId",
                        column: x => x.locationId,
                        principalTable: "Locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialSubLots_MaterialLots_lotNumber",
                        column: x => x.lotNumber,
                        principalTable: "MaterialLots",
                        principalColumn: "lotNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssueLots",
                columns: table => new
                {
                    issueLotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    requestedQuantity = table.Column<double>(type: "float", nullable: false),
                    issueLotStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    materialLotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    inventoryIssueEntryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueLots", x => x.issueLotId);
                    table.ForeignKey(
                        name: "FK_IssueLots_InventoryIssueEntries_inventoryIssueEntryId",
                        column: x => x.inventoryIssueEntryId,
                        principalTable: "InventoryIssueEntries",
                        principalColumn: "inventoryIssueEntryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueLots_MaterialLots_materialLotId",
                        column: x => x.materialLotId,
                        principalTable: "MaterialLots",
                        principalColumn: "lotNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptLots",
                columns: table => new
                {
                    receiptLotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    importedQuantity = table.Column<double>(type: "float", nullable: false),
                    receiptLotStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryReceiptEntryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptLots", x => x.receiptLotId);
                    table.ForeignKey(
                        name: "FK_ReceiptLots_InventoryReceiptEntries_InventoryReceiptEntryId",
                        column: x => x.InventoryReceiptEntryId,
                        principalTable: "InventoryReceiptEntries",
                        principalColumn: "inventoryReceiptEntryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssueSublots",
                columns: table => new
                {
                    issueSublotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    requestedQuantity = table.Column<double>(type: "float", nullable: false),
                    sublotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    issueLotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueSublots", x => x.issueSublotId);
                    table.ForeignKey(
                        name: "FK_IssueSublots_IssueLots_issueLotId",
                        column: x => x.issueLotId,
                        principalTable: "IssueLots",
                        principalColumn: "issueLotId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueSublots_MaterialSubLots_sublotId",
                        column: x => x.sublotId,
                        principalTable: "MaterialSubLots",
                        principalColumn: "subLotId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptSublots",
                columns: table => new
                {
                    receiptLotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    receiptSublotId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    importedQuantity = table.Column<double>(type: "float", nullable: false),
                    subLotStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptSublots", x => x.receiptLotId);
                    table.ForeignKey(
                        name: "FK_ReceiptSublots_Locations_locationId",
                        column: x => x.locationId,
                        principalTable: "Locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptSublots_ReceiptLots_receiptLotId",
                        column: x => x.receiptLotId,
                        principalTable: "ReceiptLots",
                        principalColumn: "receiptLotId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssueEntries_inventoryIssueId",
                table: "InventoryIssueEntries",
                column: "inventoryIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssueEntries_materialId",
                table: "InventoryIssueEntries",
                column: "materialId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssues_customerId",
                table: "InventoryIssues",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssues_pesonId",
                table: "InventoryIssues",
                column: "pesonId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIssues_warehouseId",
                table: "InventoryIssues",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLogs_lotNumber",
                table: "InventoryLogs",
                column: "lotNumber");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLogs_warehouseId",
                table: "InventoryLogs",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceiptEntries_InventoryReceiptId",
                table: "InventoryReceiptEntries",
                column: "InventoryReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceiptEntries_materialId",
                table: "InventoryReceiptEntries",
                column: "materialId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceipts_personId",
                table: "InventoryReceipts",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceipts_supplierId",
                table: "InventoryReceipts",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceipts_warehouseId",
                table: "InventoryReceipts",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueLots_inventoryIssueEntryId",
                table: "IssueLots",
                column: "inventoryIssueEntryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueLots_materialLotId",
                table: "IssueLots",
                column: "materialLotId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueSublots_issueLotId",
                table: "IssueSublots",
                column: "issueLotId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueSublots_sublotId",
                table: "IssueSublots",
                column: "sublotId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_warehouseId",
                table: "Locations",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialClassProperties_materialClassId",
                table: "MaterialClassProperties",
                column: "materialClassId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialLotAdjustments_lotNumber",
                table: "MaterialLotAdjustments",
                column: "lotNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialLotAdjustments_personId",
                table: "MaterialLotAdjustments",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialLotAdjustments_warehouseId",
                table: "MaterialLotAdjustments",
                column: "warehouseId");

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

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSubLots_locationId",
                table: "MaterialSubLots",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSubLots_lotNumber",
                table: "MaterialSubLots",
                column: "lotNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptLots_InventoryReceiptEntryId",
                table: "ReceiptLots",
                column: "InventoryReceiptEntryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptSublots_locationId",
                table: "ReceiptSublots",
                column: "locationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentClassProperties");

            migrationBuilder.DropTable(
                name: "EquipmentProperties");

            migrationBuilder.DropTable(
                name: "InventoryLogs");

            migrationBuilder.DropTable(
                name: "IssueSublots");

            migrationBuilder.DropTable(
                name: "MaterialClassProperties");

            migrationBuilder.DropTable(
                name: "MaterialLotAdjustments");

            migrationBuilder.DropTable(
                name: "MaterialLotProperties");

            migrationBuilder.DropTable(
                name: "MaterialProperties");

            migrationBuilder.DropTable(
                name: "ReceiptSublots");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "IssueLots");

            migrationBuilder.DropTable(
                name: "MaterialSubLots");

            migrationBuilder.DropTable(
                name: "ReceiptLots");

            migrationBuilder.DropTable(
                name: "EquipmentClasses");

            migrationBuilder.DropTable(
                name: "InventoryIssueEntries");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "MaterialLots");

            migrationBuilder.DropTable(
                name: "InventoryReceiptEntries");

            migrationBuilder.DropTable(
                name: "InventoryIssues");

            migrationBuilder.DropTable(
                name: "InventoryReceipts");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "MaterialClasses");
        }
    }
}
