using System;
using System.Collections.Generic;
using System.Text;

namespace _09_Custom_Generic_Linked_List
{
    public class Node<T>
    {
        public Node(int value)
        {
            Value = value;
        }
        public int Value { get; set; }

        public Node Next { get; set; }

    }
}
