using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public abstract class Person
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        public Person(string name, int id)
        {
            Name = name;
            ID = id;
        }
    }
}
