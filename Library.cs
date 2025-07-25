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
        public List<Book> BorrowedBooks { get; private set; }

        public Library()
        {
            Books = new List<Book>();
            Members = new List<Member>();
            BorrowedBooks = new List<Book>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void BorrowBook(Book book)
        {
            BorrowedBooks.Add(book);
        }

        public void AddMember(Member member)
        {
            Members.Add(member);
        }

        public void Login(Member member)
        {

        }

        public void LoadMembersFromFile()
        {
            if (File.Exists("MemberInfo.txt"))
            {
                var lines = File.ReadAllLines("MemberInfo.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split(", ");
                    string name = parts[0].Split(": ")[1]; // Extract name after "Name: "
                    int id = int.Parse(parts[1].Split(": ")[1]); // Extract ID after "ID: "
                    Members.Add(new Member(name, id, this)); //Add members to Members list
                }
            }
        }

        public Member FindMemberByName(string name)
        {
            return Members.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Member FindMemberById(int id)
        {
            return Members.FirstOrDefault(m => m.ID == id);
        }
        
         public void LoadBooksFromFile()
        {
            if (File.Exists("Books.txt"))
            {
                var lines = File.ReadAllLines("Books.txt");
                foreach (var line in lines)
                {
                    try
                    {
                        var parts = line.Split(", ");
                        if (parts.Length >= 3) // Ensure there are enough parts
                        {
                            string title = parts[0].Split(": ")[1]; // Extract title after "Title: "
                            string author = parts[1].Split(": ")[1]; // Extract author after "Author: "
                            long isbn = long.Parse(parts[2].Split(": ")[1]); // Extract ISBN after "ISBN: "

                            Book book = new Book
                            {
                                Title = title,
                                Author = author,
                                ISBN = isbn,
                                IsAvailable = true // Default to available
                            };
                            Books.Add(book);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing book from line '{line}': {ex.Message}");
                    }
                }
            }
        }
    }
}
