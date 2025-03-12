using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.APIs.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewTalbe_PersonProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonProperties",
                columns: table => new
                {
                    propertyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    propertyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    propertyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitOfMeasure = table.Column<int>(type: "int", nullable: false),
                    personId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProperties", x => x.propertyId);
                    table.ForeignKey(
                        name: "FK_PersonProperties_Persons_personId",
                        column: x => x.personId,
                        principalTable: "Persons",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonProperties_personId",
                table: "PersonProperties",
                column: "personId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonProperties");
        }
    }
}
