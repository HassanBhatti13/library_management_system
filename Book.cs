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
        public string Title { get; set; }
        public string Author { get; set; }
        public long ISBN { get; set; }
        public bool IsAvailable { get; set; }

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
