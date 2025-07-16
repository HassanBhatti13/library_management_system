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

            using (StreamWriter writer = new StreamWriter("Books.txt", true))
            {
                writer.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {book.IsAvailable}");
            }
        }

        public void RemoveBook()
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

            // Update Books.txt by removing the book's entry
            if (File.Exists("Books.txt"))
            {
                try
                {
                    
                    var lines = File.ReadAllLines("Books.txt").ToList(); // Read all lines from the file
                    
                    var updatedLines = lines.Where(line => // Filter out the line matching the book to remove
                    {
                        var parts = line.Split(", ");
                        if (parts.Length >= 3)
                        {
                            string title = parts[0].Split(": ")[1];
                            long isbnFromFile = long.Parse(parts[2].Split(": ")[1]);
                            return !(title.Equals(bookToRemove.Title, StringComparison.OrdinalIgnoreCase) || isbnFromFile == bookToRemove.ISBN);
                        }
                        return true; // Keep lines that don't match the format
                    }).ToList();

                    // Write the updated lines back to the file
                    File.WriteAllLines("Books.txt", updatedLines);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating Books.txt: {ex.Message}");
                }
            }
        
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
