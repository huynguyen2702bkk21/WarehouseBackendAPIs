using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReceiptSublotTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptSublots",
                table: "ReceiptSublots");

            migrationBuilder.AlterColumn<string>(
                name: "receiptSublotId",
                table: "ReceiptSublots",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptSublots",
                table: "ReceiptSublots",
                column: "receiptSublotId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptSublots_receiptLotId",
                table: "ReceiptSublots",
                column: "receiptLotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptSublots",
                table: "ReceiptSublots");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptSublots_receiptLotId",
                table: "ReceiptSublots");

            migrationBuilder.AlterColumn<string>(
                name: "receiptSublotId",
                table: "ReceiptSublots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptSublots",
                table: "ReceiptSublots",
                column: "receiptLotId");
        }
    }
}
