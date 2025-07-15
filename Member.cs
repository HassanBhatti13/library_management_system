using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Library_Management_System
{
    public class Member : Person
    {
        private IBookCatalogue catalogue;

        public Member(string name, int id, IBookCatalogue catalogue) : base(name, id)
        {
            this.catalogue = catalogue;
        }
        public void ViewAllBooks()
        {
            List<Book> books = catalogue.GetCatalogue();
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine("\nBook " + (i + 1) + ":");
                Console.WriteLine("Title: " + books[i].title);
                Console.WriteLine("Author: " + books[i].author);
                Console.WriteLine("ISBN: " + books[i].isbn);
                Console.WriteLine();
            }
        }
        public void BorrowBook()
        {
            Console.WriteLine("Enter the book details you want to borrow:");
            Console.WriteLine("");
        }

        public void ReturnBook()
        {

        }

        public void ViewBorrowedBooks()
        {
            
        }
    }
}
