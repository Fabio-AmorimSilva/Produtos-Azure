namespace ProdutosAzure.Infrastructure;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure(IConfiguration configuration)
        {
            services.AddDbContext(configuration);
        
            return services;
        }

        private IServiceCollection AddDbContext(IConfiguration configuration)
        {
            services.AddDbContext<ProductAzureDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
            
            services.AddScoped<IProductAzureDbContext>(provider => provider.GetRequiredService<ProductAzureDbContext>());
        
            return services;
        }
    }
}