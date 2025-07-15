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
            Console.Clear();
            Console.WriteLine("\n=== Add new book=== \n");

            Console.Write("Enter book title: ");
            book.Title = Console.ReadLine();

            Console.Write("Enter author name: ");
            book.Author = Console.ReadLine();

            Console.Write("Enter book ISBN: ");
            book.ISBN = Convert.ToInt64(Console.ReadLine());

            book.IsAvailable = true;                // New books are available by default

            _library.AddBook(book);
            Console.WriteLine("\nBook added successfully!");
        }

        public void RemoveBook(Book book)
        {
            Console.Clear();
            Console.WriteLine("\n=== Remove books by Title or ISBN ===");

            Console.Write("\nEnter Title or ISBN: ");
            string query = Console.ReadLine();

            Book bookToRemove = null;

            if (long.TryParse(query, out long isbn))
            {
                bookToRemove = _library.Books.FirstOrDefault(b => b.ISBN == isbn);
            }
            else
            {
                bookToRemove = _library.Books.FirstOrDefault(b => b.Title.Equals(query, StringComparison.OrdinalIgnoreCase));
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
        }

        public void ViewBookCatalogue()
        {
            Console.Clear();
            Console.WriteLine("\n=== Library Book Catalogue ===\n");
            if (_library.Books.Count == 0)
            {
                Console.WriteLine("No books available.");
            }
            else
            {
                foreach (var book in _library.Books)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {(book.IsAvailable ? "Yes" : "No")}");
                }
            }
        }
    }
}
