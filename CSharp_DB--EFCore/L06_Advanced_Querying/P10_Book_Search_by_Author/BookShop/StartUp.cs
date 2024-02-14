namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Data.SqlTypes;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string subString = Console.ReadLine();                               // P10
            Console.WriteLine(GetBooksByAuthor(db, subString));

        }


        public static string GetBooksByAuthor(BookShopContext context, string subString)    // P10
        {
            var books = context.Books
                .Include(b => b.Author)
                .Where(b => b.Author.LastName.ToLower().StartsWith(subString.ToLower()))
                .Select(b => new
                {
                    b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName
                })
                //.OrderBy(b => b.)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} ({b.AuthorName})"));
        }

    }
}


