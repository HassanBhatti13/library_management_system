using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class BookCatalogue : IBookCatalogue
    {
        private List<Book> catalogue = new List<Book>();
        public void AddBook(Book book)
        {
            catalogue.Add(book);
        }

        public void RemoveBook(Book book)
        {
            catalogue.Remove(book);
        }

        public List<Book> GetCatalogue()
        {
            return catalogue;
        }
    }
}
