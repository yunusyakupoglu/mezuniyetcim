using Microsoft.EntityFrameworkCore.Migrations;

namespace mezuniyetcim.com.Data.Migrations
{
    public partial class tblProductV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "misyons",
                columns: table => new
                {
                    misyonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    misyonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    misyonDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_misyons", x => x.misyonId);
                });

            migrationBuilder.CreateTable(
                name: "productCategories",
                columns: table => new
                {
                    productCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productCategories", x => x.productCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "vizyons",
                columns: table => new
                {
                    vizyonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vizyonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vizyonDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vizyons", x => x.vizyonId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_products_productCategories_productCategoryId",
                        column: x => x.productCategoryId,
                        principalTable: "productCategories",
                        principalColumn: "productCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "productImages",
                columns: table => new
                {
                    fileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productImages", x => x.fileId);
                    table.ForeignKey(
                        name: "FK_productImages_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productImages_ProductID",
                table: "productImages",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_products_productCategoryId",
                table: "products",
                column: "productCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "misyons");

            migrationBuilder.DropTable(
                name: "productImages");

            migrationBuilder.DropTable(
                name: "vizyons");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "productCategories");
        }
    }
}
