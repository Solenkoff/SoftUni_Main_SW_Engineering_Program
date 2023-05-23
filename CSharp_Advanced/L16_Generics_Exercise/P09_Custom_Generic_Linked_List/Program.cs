using System;

namespace _09_Custom_Generic_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftuniLinkedList linkedList = new SoftuniLinkedList();

            linkedList.AddHead(new Node(1));
            linkedList.AddHead(new Node(2));
            linkedList.AddHead(new Node(3));
            linkedList.AddHead(new Node(4));

            var currNode = linkedList.Head;



            while (currNode != null)
            {
                Console.WriteLine(currNode);
                currNode = currNode.Next;
            }
        }
    }
}
