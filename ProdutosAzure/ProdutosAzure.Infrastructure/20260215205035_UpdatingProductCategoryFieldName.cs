using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdutosAzure.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingProductCategoryFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductCategory",
                table: "Products",
                newName: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Products",
                newName: "ProductCategory");
        }
    }
}
