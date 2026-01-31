namespace ProdutosAzure.Application.Services.Products;

public interface IProductService
{
    Task<IEnumerable<ListProductDto>> ListProductsAsync();
    Task<Guid> CreateAsync(CreateProductDto dto);
    Task UpdateAsync(UpdateProductDto dto);
    Task DeleteAsync(Guid productId);
}