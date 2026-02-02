namespace ProdutosAzure.Web.Controllers;

public class ProductsController(IProductService productService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await productService.ListProductsAsync();
        
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        await productService.CreateAsync(dto);
        
        return RedirectToAction(nameof(Index));
    }
}