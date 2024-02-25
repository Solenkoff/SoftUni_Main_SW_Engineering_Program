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

            Console.WriteLine(GetSoldProducts(context));                                    // P06

        }


        public static string GetSoldProducts(ProductShopContext context)         // P06
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0 && u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(ps => ps.BuyerId != null)
                        .Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price,
                            buyerFirstName = ps.Buyer!.FirstName,
                            buyerLastName = ps.Buyer.LastName
                        })
                        .ToArray()
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToArray();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            return json;
        }

    }
}