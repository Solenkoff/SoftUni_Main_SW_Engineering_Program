﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public string Start()
        {
            return "Engine start";
        }
        public string Stop()
        {
            return "Breaaak!";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} Seat {Model}");
            sb.AppendLine(this.Start());
            sb.Append(this.Stop());
            return sb.ToString();
        }

    }
}