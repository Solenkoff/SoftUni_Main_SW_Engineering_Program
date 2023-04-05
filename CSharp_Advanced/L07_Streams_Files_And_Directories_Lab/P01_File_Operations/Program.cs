using System;
using System.IO;

namespace _01_File_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../Input.txt"))
            {
                string currentRow = reader.ReadLine();
                int row = 0;

                using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                {
                    while (currentRow != null)
                    {
                        if (row % 2 != 0)
                        {
                            writer.WriteLine(currentRow);
                        }

                        row++;
                        currentRow = reader.ReadLine();

                    }
                }
            }

        }
    }
}
