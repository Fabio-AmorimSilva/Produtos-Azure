namespace ProdutosAzure.Infrastructure.Data;

public class ProductAzureDbContext(DbContextOptions<ProductAzureDbContext> options) : DbContext(options), IProductAzureDbContext
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}