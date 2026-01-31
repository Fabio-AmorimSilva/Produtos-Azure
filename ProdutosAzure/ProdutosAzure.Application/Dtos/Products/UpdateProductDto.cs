namespace ProdutosAzure.Application.Dtos.Products;

public record UpdateProductDto
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ProductCategory ProductCategory { get; set; }
}