namespace ProdutosAzure.Domain.UnitTests.Entities.Products;

public class ConstructorTests
{
    [Fact]
    public void Constructor_ShouldCreateProductCorrectly()
    {
        const string name = "Rear Flashlights";
        const ProductCategory category = ProductCategory.Electronics;

        var product = new Product(
            name: name,
            category: category
        );

        product.ShouldNotBeNull();
        product.Id.ShouldNotBe(Guid.Empty);
        product.Name.ShouldBe(name);
        product.Category.ShouldBe(category);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_ShouldThrowException_WhenNameIsWhitespace(string name)
    {
        var action = () => new Product(
            name: name,
            category: ProductCategory.Electronics
        );

        action.ShouldThrow<ArgumentException>()
            .ParamName
            .ShouldBe("name");
    }
}