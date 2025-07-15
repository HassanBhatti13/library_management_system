using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public interface IBookCatalogue
    {
        void AddBook(Book book);
        List<Book> GetCatalogue();
    }
}
