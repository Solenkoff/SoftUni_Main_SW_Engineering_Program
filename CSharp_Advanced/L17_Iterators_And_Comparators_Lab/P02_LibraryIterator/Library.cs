using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library<Book> : IEnumerable<Book>
    {

        private readonly List<Book> books;

        public Library(IEnumerable<Book> books)
        {
            this.books = new List<Book>(books);
        }

        public Library()
        {
            books = new List<Book>();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIteraror(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

             
    }
}
