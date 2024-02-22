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

            string productsJson = File.ReadAllText("../../../Datasets/products.json");      // P02
            Console.WriteLine(ImportProducts(context, productsJson));

        }


        public static string ImportProducts(ProductShopContext context, string inputJson)    // P02
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

    }
}