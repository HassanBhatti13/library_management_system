using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public abstract class Person
    {
        private string Name { get; set; }
        private int ID { get; set; }
        public Person(string name, int id)
        {
            Name = name;
            ID = id;
        }
    }
}
