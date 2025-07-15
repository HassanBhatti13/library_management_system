using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Library
    {
        public List<Book> Books { get; private set; }
        public List<Member> Members { get; private set; }

        public Library()
        {
            Books = new List<Book>();
            Members = new List<Member>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        
        // public void AddMember()
        // {

        // }
        // public void GetAvailableBooks()
        // {

        // }
    }
}
