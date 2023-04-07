using System;

namespace _04_Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {





            string[] file1 = File.ReadAllLines("*DIRECTORY*\FIRSTFILE.txt");
            string[] file2 = File.ReadAllLines("*DIRECTORY*\SECONDFILE.txt");

            using (StreamWriter writer = File.CreateText(@"*DIRECTORY*\FINALOUTPUT.txt"))
            {
                int lineNum = 0;
                while (lineNum < file1.Length || lineNum < file2.Length)
                {
                    if (lineNum < file1.Length)
                        writer.WriteLine(file1[lineNum]);
                    if (lineNum < file2.Length)
                        writer.WriteLine(file2[lineNum]);
                    lineNum++;
                }
            }


        }
    }
}
