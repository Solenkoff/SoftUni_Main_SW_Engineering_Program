namespace WebShopDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebShopDemo.Core.Contracts;

    /// <summary>
    ///  Web Shop Products
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        /// <summary>
        ///  List all products
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAll();
            ViewData["Title"] = "Products";

            return View(products);
        }
    }
}
