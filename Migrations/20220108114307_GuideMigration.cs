using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRoutes.Migrations
{
    public partial class GuideMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Route",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "guideID",
                table: "Route",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Guide",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guide", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Route_guideID",
                table: "Route",
                column: "guideID");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Guide_guideID",
                table: "Route",
                column: "guideID",
                principalTable: "Guide",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_Guide_guideID",
                table: "Route");

            migrationBuilder.DropTable(
                name: "Guide");

            migrationBuilder.DropIndex(
                name: "IX_Route_guideID",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "guideID",
                table: "Route");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Route",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");
        }
    }
}
