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
            //DbInitializer.ResetDatabase(db);

            //string commandInput = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, commandInput));       // P02

            //Console.WriteLine(GetGoldenBooks(db));                               // P03

            //Console.WriteLine(GetBooksByPrice(db));                              // P04

            //int yearInput = int.Parse(Console.ReadLine());                       // P05
            //Console.WriteLine(GetBooksNotReleasedIn(db, yearInput));              

            //string input = Console.ReadLine();                                   // P06
            //Console.WriteLine(GetBooksByCategory(db, input));

            //string date = Console.ReadLine();                                    // P07
            //Console.WriteLine(GetBooksReleasedBefore(db, date));

            //string endingString = Console.ReadLine();                            // P08
            //Console.WriteLine(GetAuthorNamesEndingIn(db, endingString));

            //string subString = Console.ReadLine();                               // P09
            //Console.WriteLine(GetBookTitlesContaining(db, subString));

            //string subString = Console.ReadLine();                               // P10
            //Console.WriteLine(GetBooksByAuthor(db, subString));

            //int lengthCheck = int.Parse(Console.ReadLine());                     // P11
            //Console.WriteLine(CountBooks(db, lengthCheck)); 

            //Console.WriteLine(CountCopiesByAuthor(db));                          // P12

            //Console.WriteLine(GetTotalProfitByCategory(db));                     // P13

            //Console.WriteLine(GetMostRecentBooks(db));                           // P14

            //IncreasePrices(db);                                                  // P15

            //Console.WriteLine(RemoveBooks(db));                                  // P16
        }


        public static string GetBooksByAgeRestriction(BookShopContext context, string command)  // P02
        {
            if (!Enum.TryParse<AgeRestriction>(command, true, out var ageRestriction))
            {
                return $"{command} is not a valid age restriction";
            }

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetGoldenBooks(BookShopContext context)         // P03
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => new
                {
                    b.BookId,
                    b.Title
                })
                .OrderBy(b => b.BookId)
                .ToList();


            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetBooksByPrice(BookShopContext context)            // P04
        {
            var books = context.Books
                            .Where(b => b.Price > 40)
                            .Select(b => new
                            {
                                b.Title,
                                b.Price
                            })
                            .OrderByDescending(b => b.Price)
                            .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:f2}"));
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)       // P05
        {
            var books = context.Books
                            .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                            .Select(b => new
                            {
                                b.Title
                            })
                            .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetBooksByCategory(BookShopContext context, string input)     // P06
        {
            string[] categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            var books = context.Books
                .Select(b => new
                {
                    b.Title,
                    b.BookCategories
                })
                .Where(b => b.BookCategories.All(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)   // P07
        {
            DateTime givenDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                        .Where(b => b.ReleaseDate < givenDate)
                        .Select(b => new
                        {
                            b.Title,
                            b.EditionType,
                            b.Price,
                            b.ReleaseDate
                        })
                        .OrderByDescending(b => b.ReleaseDate)
                        .ToList();

            return string.Join(Environment.NewLine,
                books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}"));
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

        public static string GetBookTitlesContaining(BookShopContext context, string subString)    // P09
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(subString.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
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

        public static int CountBooks(BookShopContext context, int lengthCheck)       // P11
        {
            return context.Books.Count(b => b.Title.Length > lengthCheck);
        }

        public static string CountCopiesByAuthor(BookShopContext context)          // P12
        {
            var result = context.Authors
                .Include(a => a.Books)
                .Select(a => new
                {
                    AuthorFullName = string.Join(" ", a.FirstName, a.LastName),
                    CountOfBookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.CountOfBookCopies)
                .ToList();

            return string.Join(Environment.NewLine, result.Select(a => $"{a.AuthorFullName} - {a.CountOfBookCopies}"));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)    // P13
        {
            var categoriesProfit = context.Categories
                .Include(c => c.CategoryBooks)
                    .ThenInclude(cb => cb.Book)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    CategoryTotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.CategoryTotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToList();

            return string.Join(Environment.NewLine, categoriesProfit.Select(c => $"{c.CategoryName} ${c.CategoryTotalProfit:f2}"));
        }

        public static string GetMostRecentBooks(BookShopContext context)         // P14
        {
            var categoriesWithBooks = context.Categories
               //.Include(c => c.CategoryBooks)
               //    .ThenInclude(cb => cb.Book)
               .Select(c => new
               {
                   CategoryName = c.Name,
                   MostRecentBooks = c.CategoryBooks
                      .OrderByDescending(cb => cb.Book.ReleaseDate)
                      .Take(3)
                      .Select(cb => new
                      {
                          BookTitle = cb.Book.Title,
                          BookReleaseYear = cb.Book.ReleaseDate.Value.Year
                      })
                      .AsEnumerable()
               })
               .OrderBy(c => c.CategoryName)
               .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categoriesWithBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.MostRecentBooks)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)        // P15
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010).ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
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


