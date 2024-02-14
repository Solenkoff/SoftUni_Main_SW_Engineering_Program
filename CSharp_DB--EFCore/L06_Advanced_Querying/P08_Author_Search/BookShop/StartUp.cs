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

            string endingString = Console.ReadLine();                            // P08
            Console.WriteLine(GetAuthorNamesEndingIn(db, endingString));

        }


        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)   // P08
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    AuthorFullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.AuthorFullName)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(a => a.AuthorFullName));
        }

    }
}


