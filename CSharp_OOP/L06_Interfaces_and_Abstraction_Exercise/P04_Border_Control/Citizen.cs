using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson
    {

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
       
    }
}
