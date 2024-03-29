﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        public Animal(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {this.Name}");

            return sb.ToString();
        }
    }
}
