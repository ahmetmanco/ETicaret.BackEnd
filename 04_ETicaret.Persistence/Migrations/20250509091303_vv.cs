using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _04_ETicaret.Persistence_.Migrations
{
    /// <inheritdoc />
    public partial class vv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Productss_ProductId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_ProductId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Files");

            migrationBuilder.CreateTable(
                name: "ProductProductImageFile",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "integer", nullable: false),
                    productImageFilesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductImageFile", x => new { x.ProductsId, x.productImageFilesId });
                    table.ForeignKey(
                        name: "FK_ProductProductImageFile_Files_productImageFilesId",
                        column: x => x.productImageFilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductProductImageFile_Productss_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Productss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductImageFile_productImageFilesId",
                table: "ProductProductImageFile",
                column: "productImageFilesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductImageFile");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Files",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_ProductId",
                table: "Files",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Productss_ProductId",
                table: "Files",
                column: "ProductId",
                principalTable: "Productss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
