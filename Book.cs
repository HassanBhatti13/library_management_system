using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Book
    {
        public string Title;
        public string Author;
        public long ISBN;
        public bool IsAvailable;

        // public string title { get; set; }
        // public string author { get; set; }
        // public long isbn { get; set; }
        // public bool isAvailable { get; set; }

        public Book()
        {
            IsAvailable = true;
        }

        public void Borrow()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                Console.WriteLine($"Book '{Title} borrowed successfully.");
            }
            else
            {
                Console.WriteLine($"Book '{Title} is not available.");
            }

        }
        public void Return()
        {
            if (!IsAvailable)
            {
                IsAvailable = true;
                Console.WriteLine($"Book '{Title}' returned successfully.");
            }
            else
            {
                Console.WriteLine($"Book '{Title}' was not borrowed.");
            }
        }
    }
}
