using System;

namespace _03_Stack
{
    class Program
    {
        static void Main(string[] args)
        {

            MyStack<int> myStack = new MyStack<int>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commands = input.Split(new string[] {" ", ", "}, StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "Push")
                {
                    for (int i = 1; i < commands.Length; i++)
                    {
                        int item = int.Parse(commands[i]);
                        myStack.Push(item);
                    }
                }
                else if(command == "Pop")
                {
                    try
                    {
                        myStack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);                        
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(string.Join(Environment.NewLine, myStack));
        }
    }
}
