using System;


namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private class ListNode
        {
            public int Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }

            public ListNode(int value)
            {
                this.Value = value;
            }

        }

        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirstElement(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                ListNode newHead = new ListNode(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }
            Count++;
        }

        public void AddLast(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }
            Count++;
        }


        public int RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            var firstElement = this.head.Value;
            this.head = this.head.NextNode;
            if (this.head != null)
            {
                this.head.PreviousNode = null;

            }
            else
            {
                this.tail = null;
            }
            Count--;

            return firstElement;
        }


        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;
            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }
            Count--;

            return lastElement;
        }


        public void ForEach(Action<int> action)
        {
            var currNode = this.head;
            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.NextNode;
            }
        }

        public void ForEachFromTail(Action<int> action)
        {
            var currNode = this.tail;                    //Reverse of ForEach
            while (currNode != null)                     //<int> could be ListNode or Node or...
            {
                action(currNode.Value);
                currNode = currNode.PreviousNode;
            }
        }


        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            var currNode = this.head;
            int counter = 0;
            while (currNode != null)
            {
                array[counter] = currNode.Value;
                currNode = currNode.NextNode;
                counter++;
            }

            return array;
        }

    }
}
