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

            Console.WriteLine(RemoveBooks(db));                                  // P16

        }


        public static int RemoveBooks(BookShopContext context)         // P16
        {
            var books = context.Books
                .Where(b => b.Copies < 4200).ToList();

            context.RemoveRange(books);

            context.SaveChanges();

            return books.Count;
            //var bookCategoryLogs = context.BooksCategories.AsEnumerable()
            //    .Where(bc => books.Any(b => b.BookId == bc.BookId)).ToList();
        }

    }
}


