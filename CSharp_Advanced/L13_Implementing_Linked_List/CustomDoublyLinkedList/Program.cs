using System;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {

            DoublyLinkedList someList = new DoublyLinkedList();

            someList.ForEach(n => Console.WriteLine(n));

        }
    }
}
