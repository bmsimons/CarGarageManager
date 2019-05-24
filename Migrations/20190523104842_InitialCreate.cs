using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarGarageManager.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBrand",
                columns: table => new
                {
                    CarBrandID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarBrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrand", x => x.CarBrandID);
                });

            migrationBuilder.CreateTable(
                name: "CarModel",
                columns: table => new
                {
                    CarModelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarBrandFK = table.Column<int>(nullable: false),
                    CarModelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.CarModelID);
                    table.ForeignKey(
                        name: "FK_CarModel_CarBrand_CarBrandFK",
                        column: x => x.CarBrandFK,
                        principalTable: "CarBrand",
                        principalColumn: "CarBrandID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarModelFK = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Mileage = table.Column<int>(nullable: false),
                    CarBrandID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_Car_CarBrand_CarBrandID",
                        column: x => x.CarBrandID,
                        principalTable: "CarBrand",
                        principalColumn: "CarBrandID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Car_CarModel_CarModelFK",
                        column: x => x.CarModelFK,
                        principalTable: "CarModel",
                        principalColumn: "CarModelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarBrandID",
                table: "Car",
                column: "CarBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarModelFK",
                table: "Car",
                column: "CarModelFK");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_CarBrandFK",
                table: "CarModel",
                column: "CarBrandFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CarModel");

            migrationBuilder.DropTable(
                name: "CarBrand");
        }
    }
}
