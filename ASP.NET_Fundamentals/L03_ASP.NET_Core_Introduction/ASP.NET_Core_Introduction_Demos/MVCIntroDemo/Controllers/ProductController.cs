
namespace MVCIntroDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    using MVCIntroDemo.ViewModels.Product;
    using Newtonsoft.Json;
    using System.Text;
    using System.Text.Json;
    using static MVCIntroDemo.Seeding.ProductsData;



    public class ProductController : Controller
    {
        public IActionResult All(string keyword)
        {
            if (String.IsNullOrWhiteSpace(keyword))
            {
                return View(Products);
            }

            IEnumerable<ProductViewModel> filteredProducts = Products
                .Where(p => p.Name.ToLower().Contains(keyword.ToLower()))
                .ToArray();

            return View(filteredProducts);
        }


        [Route("/Product/My-Products/{id?}")]
        public IActionResult ById(string id)
        {
            ProductViewModel? product = Products
                .FirstOrDefault(p => p.Id.ToString().Equals(id));
            if(product == null)
            {
                //return BadRequest();
                return this.RedirectToAction("All"); 
            }

            return this.View(product);  
        }

        public IActionResult AllAsJson()
        {
            //string jsonText = JsonConvert.SerializeObject(Products, Formatting.Indented);
            //return Json(jsonText);                  //  returns the JSON as text

            return Json(Products, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }

        public IActionResult DownloadProductsInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var product in Products)
            {
                sb
                    .AppendLine($"Product with Id: {product.Id}")
                    .AppendLine($"## Product name: {product.Name}")
                    .AppendLine($"## Price: ${product.Price:f2}")
                    .AppendLine("--------------------------------------");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
