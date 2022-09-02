using System;
using System.Linq;

namespace _02_Articles
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine()
                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            Article article = new Article(input[0], input[1], input[2]);

            int nCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < nCommands; i++)
            {
                string[] commands = Console.ReadLine()
                                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

                if (commands[0] == "Edit")
                {
                    article.Edit(commands[1]);
                }
                else if (commands[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(commands[1]);
                }
                else if (commands[0] == "Rename")
                {
                    article.Rename(commands[1]);
                }
            }

            Console.WriteLine(article.ToString());

        }

    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }


        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }


        public void Edit(string newCotent)
        {
            Content = newCotent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}
