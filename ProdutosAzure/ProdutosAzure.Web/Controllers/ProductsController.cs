namespace ProdutosAzure.Web.Controllers;

public class ProductsController(IProductService productService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var products = await productService.ListProductsAsync();
        
        return View(products);
    }
}