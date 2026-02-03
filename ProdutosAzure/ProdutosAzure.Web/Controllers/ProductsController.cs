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

    [HttpGet]
    public async Task<IActionResult> Update(Guid id)
    {
        var product = await productService.GetProductByIdAsync(id);

        var dto = new UpdateProductDto
        {
            ProductId = product?.Id ?? Guid.Empty,
            Name = product?.Name ?? string.Empty,
            ProductCategory = product!.ProductCategory
        };

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductDto dto)
    {
        await productService.UpdateAsync(dto);
        
        return RedirectToAction(nameof(Index));
    }
}