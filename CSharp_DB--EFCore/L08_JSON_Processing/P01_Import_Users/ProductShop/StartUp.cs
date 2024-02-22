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

            string userJson = File.ReadAllText("../../../Datasets/users.json");            // P01
            Console.WriteLine(ImportUsers(context, userJson));

        }


        public static string ImportUsers(ProductShopContext context, string inputJson)     // P01
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

    }
}