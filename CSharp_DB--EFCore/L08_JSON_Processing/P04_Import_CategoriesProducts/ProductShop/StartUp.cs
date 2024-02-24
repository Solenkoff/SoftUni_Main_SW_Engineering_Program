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

            string categoriesProducts = File.ReadAllText("../../../Datasets/categories-products.json");  // P04
            Console.WriteLine(ImportCategoryProducts(context, categoriesProducts));

        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)     // P04
        { 
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            context.CategoriesProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
        }

    }
}