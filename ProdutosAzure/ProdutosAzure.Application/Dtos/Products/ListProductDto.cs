namespace ProdutosAzure.Application.Dtos.Products;

public record ListProductDto
{
    public string Name { get; set; } = string.Empty;
    public ProductCategory ProductCategory { get; set; }
}