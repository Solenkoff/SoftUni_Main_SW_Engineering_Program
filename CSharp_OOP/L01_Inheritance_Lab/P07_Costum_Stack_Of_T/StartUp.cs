using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            StackOfStrings<string> stack = new StackOfStrings<string>();

            Console.WriteLine(stack.IsEmpty());

            stack.Push("Edno");
            stack.Push("Dve");
            stack.Push("Tri");
            stack.Push("Chetiri");
            stack.Push("Pet");

            stack.AddRange(new List<string>()
            {
                "Shest",
                "Sedem",
                "Osem"

            });

            Console.WriteLine(stack.IsEmpty());

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(string.Join(", ", stack));

        }
    }
}
