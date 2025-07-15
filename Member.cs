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
        private Library _mLibrary;
        public Member(string name, int id, Library library1) : base(name, id)
        {
            _mLibrary = library1;
        }
        public void ViewBookCatalogue()
        {
            Console.Clear();
            Console.WriteLine("\n=== Library Book Catalogue ===\n");
            if (_mLibrary.Books.Count == 0)
            {
                Console.WriteLine("No books available.");
            }
            else
            {
                foreach (var book in _mLibrary.Books)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {(book.IsAvailable ? "Yes" : "No")}");
                }
            }
        }
        public void AddBook(Book book)
        {
            
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
