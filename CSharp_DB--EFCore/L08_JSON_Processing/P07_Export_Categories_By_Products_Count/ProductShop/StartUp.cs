namespace ProductShop
{
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.Models;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            Console.WriteLine(GetCategoriesByProductsCount(context));                       // P07

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)     // P07
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = c.CategoriesProducts
                                  .Average(cp => cp.Product.Price).ToString("f2"),
                    totalRevenue = c.CategoriesProducts
                                  .Sum(cp => cp.Product.Price).ToString("f2")
                })
                .OrderByDescending(c => c.productsCount)
                .ToArray();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }

    }
}