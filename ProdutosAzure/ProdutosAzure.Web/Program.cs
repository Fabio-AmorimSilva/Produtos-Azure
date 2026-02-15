namespace ProdutosAzure.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder
            .Services
            .AddApplication()
            .AddInfrastructure(builder.Configuration)
            .AddHealthChecks();
        
        builder.Services.AddControllersWithViews();

        var app = builder.Build();
        
        app.MapHealthChecks("/health");

        if (app.Environment.IsProduction())
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ProductAzureDbContext>();
                db.Database.Migrate();
            }
        }
        
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        
        app.UseStaticFiles();
        
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}