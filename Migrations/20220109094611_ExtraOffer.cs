using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRoutes.Migrations
{
    public partial class ExtraOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtraCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    extra_category_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExtraOfferCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    extraofferID = table.Column<int>(type: "int", nullable: false),
                    extracategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraOfferCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExtraOfferCategory_ExtraCategory_extracategoryID",
                        column: x => x.extracategoryID,
                        principalTable: "ExtraCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraOfferCategory_ExtraOffer_extraofferID",
                        column: x => x.extraofferID,
                        principalTable: "ExtraOffer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraOfferCategory_extracategoryID",
                table: "ExtraOfferCategory",
                column: "extracategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraOfferCategory_extraofferID",
                table: "ExtraOfferCategory",
                column: "extraofferID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraOfferCategory");

            migrationBuilder.DropTable(
                name: "ExtraCategory");
        }
    }
}
