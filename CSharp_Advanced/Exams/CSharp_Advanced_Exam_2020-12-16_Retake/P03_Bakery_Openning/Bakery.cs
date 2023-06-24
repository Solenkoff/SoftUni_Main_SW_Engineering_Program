using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {

        private List<Employee> data;

        public Bakery(string name, int capacity)
        {           
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;


        public void Add(Employee employee)
        {
            if(this.data.Count < this.Capacity)
            {
                this.data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);

            if(employee != null)
            {
                data.Remove(employee);
                return true;
            }

            return false;
        }


        public Employee GetOldestEmployee()
        {
            Employee oldest = this.data.OrderByDescending(x => x.Age).FirstOrDefault();
        
            return oldest;
        }


        public Employee GetEmployee(string name)
        {
            Employee employee = this.data.FirstOrDefault(x => x.Name == name);

            return employee;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }


    }
}
