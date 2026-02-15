namespace ProdutosAzure.Domain.Entities;

public class Product
{
    public const int NameMaxLength = 150;
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public ProductCategory Category { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private Product()
    {
    }

    public Product(
        string name,
        ProductCategory category
    )
    {
        Guard.IsNotWhiteSpace(name);
        Guard.IsLessThanOrEqualTo(name.Length, NameMaxLength, nameof(name));
        
        Id = Guid.NewGuid();
        Name = name;
        Category = category;
        CreatedAt = DateTime.Now;
    }

    public void Update(
        string name,
        ProductCategory productCategory
    )
    {
        Guard.IsNotNullOrWhiteSpace(name);
        Guard.IsLessThanOrEqualTo(name.Length, NameMaxLength, nameof(name));
        
        Name = name;
        Category = productCategory;
        UpdatedAt = DateTime.Now;
    }
}