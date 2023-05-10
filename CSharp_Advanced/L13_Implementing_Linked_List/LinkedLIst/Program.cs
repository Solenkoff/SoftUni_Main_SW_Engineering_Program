using System;

namespace LinkedLIst
{
    class Program
    {
        static void Main(string[] args)
        {

            //Node head = new Node(1);
            //Node node2 = new Node(2);
            //Node node3 = new Node(3);
            //Node node4 = new Node(4);

            //head.Next = node2;
            //node2.Next = node3;
            //node3.Next = node4;

            //Node currNode = head;

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
