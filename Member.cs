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
      
        public void BorrowBook()
        {
            Console.Clear();
            Console.WriteLine("\n=== Enter the book details you want to BORROW ===\n");
            Console.Write("Enter book Title or ISBN: ");
            string query = Console.ReadLine();

            Book bookToBorrow = null;

            //Check book availability
            if (_mLibrary.Books.Count == 0)
            {
                Console.WriteLine("\nNo books available!");
            }
            else
            {
                //Check if query matches the book title or isbn
                if (long.TryParse(query, out long isbn))
                {
                    bookToBorrow = _mLibrary.Books.FirstOrDefault(b => b.ISBN == isbn);
                }
                else
                {
                    bookToBorrow = _mLibrary.Books.FirstOrDefault(b => b.Title.Equals(query, StringComparison.OrdinalIgnoreCase));
                }

                //Now logic of borrowing books
                if (bookToBorrow != null)
                {
                    _mLibrary.BorrowedBooks.Add(bookToBorrow);  // This adds the book to the BorrowedBooks list
                    _mLibrary.Books.Remove(bookToBorrow); //This removes the book from the Books list (available)
                    bookToBorrow.IsAvailable = false; //This marks it as unavailable
                    Console.WriteLine("\nBook borrowed successfully!");
                }
                else
                {
                    Console.WriteLine("\nBook not found!");
                }
            }
            
        }

        public void ReturnBook()
        {
            Console.Clear();
            Console.WriteLine("\n=== Enter the book details you want to RETURN ===\n");
            Console.Write("Enter book Title or ISBN: ");
            string query = Console.ReadLine();

            Book bookToReturn = null;
             //Check book availability
            if (_mLibrary.BorrowedBooks.Count == 0)
            {
                Console.WriteLine("\nYou have not borrowed any books!");
            }
            else
            {
                //Check if query matches the book title or isbn
                if (long.TryParse(query, out long isbn))
                {
                    bookToReturn = _mLibrary.BorrowedBooks.FirstOrDefault(b => b.ISBN == isbn);
                }
                else
                {
                    bookToReturn = _mLibrary.BorrowedBooks.FirstOrDefault(b => b.Title.Equals(query, StringComparison.OrdinalIgnoreCase));
                }

                //Now logic of borrowing books
                if (bookToReturn != null)
                {
                    _mLibrary.BorrowedBooks.Remove(bookToReturn); //This removes the book from BorrowedBooks list
                    _mLibrary.Books.Add(bookToReturn);            // This Adds the book back to the Books list

                    bookToReturn.IsAvailable = true; //This marks it as available once again
                    Console.WriteLine("\nBook returned successfully!");
                }
                else
                {
                    Console.WriteLine("\nBook not found!");
                }
            }
        }

        public void ViewBorrowedBooks()
        {
            Console.Clear();
            Console.WriteLine("\n=== Your Borrowd Books ===\n");
            if (_mLibrary.BorrowedBooks.Count == 0)
            {
                Console.WriteLine("No books borrowed!");
            }
            else
            {
                foreach (var book in _mLibrary.BorrowedBooks)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {(book.IsAvailable ? "Yes" : "No")}");
                }
            }
        }
    }
}
