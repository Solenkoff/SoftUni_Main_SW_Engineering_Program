using System;
using System.Collections.Generic;
using System.Text;

namespace _09_Custom_Generic_Linked_List
{
    public class SoftuniLinkedList<T>
    {
        public Node Head { get; set; }

        public void AddHead(Node node)
        {
            if (Head == null)
            {
                Head = node;
                return;
            }
            node.Next = Head;
            Head = node;
        }
    }
}
