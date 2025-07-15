using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Librarian : Person , IBookCatalogue 
    {
        private IBookCatalogue catalogue;
        private List<Book> book = new List<Book>();
        public Librarian(string name, int id, IBookCatalogue catalogue) : base(name, id)
        {
            this.catalogue = catalogue;
        }

        public void AddBook(Book book)
        {
            Console.WriteLine("\nAdd new book:\n");

            Console.Write("Enter book title: ");
            book.title = Console.ReadLine();

            Console.Write("Enter author name: ");
            book.author = Console.ReadLine();

            Console.Write("Enter book ISBN: ");
            book.isbn = Convert.ToInt32(Console.ReadLine());

            catalogue.AddBook(book);
            Console.WriteLine("\nBook added successfully!");
        }

        public void RemoveBook(Book book)
        {
            
            Console.WriteLine("\nRemove books by Title or ISBN: ");
            Console.Write("Enter Title or ISBN: ");
            string query = Console.ReadLine();

            catalogue = catalogue.Where(b => b.Title != book.Title || b.Author != book.Author || b.ISBN != book.ISBN).ToList();

            var catalogueList = catalogue;
            var bookToRemove = catalogueList.FirstOrDefault (b => b.Title == book.Title && b.Author == book.Author && b.ISBN == book.ISBN);

             if  (bookToRemove != null)
    {
                catalogue.Remove(bookToRemove);
                Console.WriteLine("Book removed successfully!");
            }

            else
            {
                Console.WriteLine("Book not found!");
            }
        }

        public void ViewBookCatalogue()
        {
            for (int i = 0; i < catalogue.Count; i++)
            {
                Console.WriteLine("\nBook " + (i + 1) + ":");
                Console.WriteLine("Title: " + catalogue[i].title);
                Console.WriteLine("Author: " + catalogue[i].author);
                Console.WriteLine("ISBN: " + catalogue[i].isbn);
                Console.WriteLine();
            }
        }
    }
}
