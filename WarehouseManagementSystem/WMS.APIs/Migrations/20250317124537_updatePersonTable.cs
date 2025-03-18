using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class updatePersonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryIssues_Persons_pesonId",
                table: "InventoryIssues");

            migrationBuilder.RenameColumn(
                name: "pesonId",
                table: "InventoryIssues",
                newName: "personId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryIssues_pesonId",
                table: "InventoryIssues",
                newName: "IX_InventoryIssues_personId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryIssues_Persons_personId",
                table: "InventoryIssues",
                column: "personId",
                principalTable: "Persons",
                principalColumn: "personId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryIssues_Persons_personId",
                table: "InventoryIssues");

            migrationBuilder.RenameColumn(
                name: "personId",
                table: "InventoryIssues",
                newName: "pesonId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryIssues_personId",
                table: "InventoryIssues",
                newName: "IX_InventoryIssues_pesonId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryIssues_Persons_pesonId",
                table: "InventoryIssues",
                column: "pesonId",
                principalTable: "Persons",
                principalColumn: "personId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
