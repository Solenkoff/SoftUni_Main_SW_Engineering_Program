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

            Console.WriteLine(GetUsersWithProducts(context));                               // P08

        }


        public static string GetUsersWithProducts(ProductShopContext context)        // P08
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = u.ProductsSold
                        .Where(ps => ps.BuyerId != null)
                        .Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price
                        })
                        .ToArray()
                })
                .OrderByDescending(u => u.soldProducts.Count())
                .ToArray();

            var result = new
            {
                usersCount = users.Count(),
                users = users.Select(u => new
                {
                    u.firstName,
                    u.lastName,
                    u.age,
                    soldProducts = new
                    {
                        count = u.soldProducts.Count(),
                        products = u.soldProducts
                    }
                })
            };

            var json = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }

    }
}