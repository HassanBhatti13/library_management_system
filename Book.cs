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
        private string Title;
        private string Author;
        private long ISBN;
        private bool IsAvailable;

        public string title { get; set; }
        public string author { get; set; }
        public long isbn { get; set; }
        public bool isAvailable { get; set; }

        public Book()
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = isAvailable;
        }

        public void Borrow()
        {

        }
        public void Return()
        {
            
        }
    }
}
