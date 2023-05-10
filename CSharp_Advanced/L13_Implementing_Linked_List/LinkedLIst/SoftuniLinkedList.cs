using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLIst
{
    class SoftuniLinkedList
    {

        public Node Head { get; set; }

        public void AddHead(Node node)
        {
            if(Head == null)
            {
                Head = node;
                return;
            }
            node.Next = Head;
            Head = node;
        }
    }
}
