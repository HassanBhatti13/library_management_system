using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Librarian : Person  
    {
        // private IBookCatalogue catalogue; //This is declared but NOT initialized!
        // private List<Book> book = new List<Book>(); //In my current logic, I am NOT adding book to this list!

        private Library _library;
        public Librarian(string name, int id, Library library) : base(name, id)
        {
            _library = library;
        }

        public void AddBook(Book book)
        {
            Console.WriteLine("\nAdd new book:\n");

            Console.Write("Enter book title: ");
            book.title = Console.ReadLine();

            Console.Write("Enter author name: ");
            book.author = Console.ReadLine();

            Console.Write("Enter book ISBN: ");
            book.isbn = Convert.ToInt64(Console.ReadLine());

            book.isAvailable = true;                // New books are available by default

            _library.AddBook(book);
            Console.WriteLine("\nBook added successfully!");
        }

        public void RemoveBook(Book book)
        {

            Console.WriteLine("\nRemove books by Title or ISBN: ");
            Console.Write("Enter Title or ISBN: ");
            string query = Console.ReadLine();

            Book bookToRemove = null;

            if (long.TryParse(query, out long isbn))
            {
                bookToRemove = _library.Books.FirstOrDefault(b => b.isbn == isbn);
            }
            else
            {
                bookToRemove = _library.Books.FirstOrDefault(b => b.title.Equals(query, StringComparison.OrdinalIgnoreCase));
            }

            if (bookToRemove != null)
            {
                _library.Books.Remove(bookToRemove);
                Console.WriteLine("\nBook removed successfully!");
            }
            else
            {
                Console.WriteLine("\nBook not found!");
            }

    //         catalogue = catalogue.Where(b => b.Title != book.Title || b.Author != book.Author || b.ISBN != book.ISBN).ToList();

            //         var catalogueList = catalogue;
            //         var bookToRemove = catalogueList.FirstOrDefault (b => b.Title == book.Title && b.Author == book.Author && b.ISBN == book.ISBN);

            //          if  (bookToRemove != null)
            // {
            //             catalogue.Remove(bookToRemove);
            //             Console.WriteLine("Book removed successfully!");
            //         }

            //         else
            //         {
            //             Console.WriteLine("Book not found!");
            //         }
        }

        public void ViewBookCatalogue()
        {
            // for (int i = 0; i < catalogue.Count; i++)
            // {
            //     Console.WriteLine("\nBook " + (i + 1) + ":");
            //     Console.WriteLine("Title: " + catalogue[i].title);
            //     Console.WriteLine("Author: " + catalogue[i].author);
            //     Console.WriteLine("ISBN: " + catalogue[i].isbn);
            //     Console.WriteLine();
            // }
        }
    }
}
