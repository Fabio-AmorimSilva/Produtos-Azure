namespace ProdutosAzure.Domain.UnitTests.Entities.Products;

public class UpdateTests
{
    [Fact]
    public void Update_ShouldUpdateProductCorrectly()
    {
        var product = new Product(
            name: "Rear Flashlights",
            category:  ProductCategory.Electronics
        );

        const string name = "Front bumpers";
        const ProductCategory category = ProductCategory.Clothes;
        
        product.Update(
            name: name,
            productCategory: category
        );
        
        product.ShouldNotBeNull();
        product.Name.ShouldBe(name);
        product.Category.ShouldBe(category);   
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Update_ShouldThrowException_WhenNameIsWhitespace(string name)
    {
        var product = new Product(
            name: "Rear Flashlights",
            category:  ProductCategory.Electronics
        );
        
        var action = () => product.Update(
            name: name,
            productCategory: ProductCategory.Electronics
        );

        action.ShouldThrow<ArgumentException>()
            .ParamName
            .ShouldBe("name");
    }
}