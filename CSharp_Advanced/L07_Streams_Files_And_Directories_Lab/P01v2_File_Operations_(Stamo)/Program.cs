using System;
using System.IO;

namespace _01v2_File_Operations__Stamo_
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var path = Path.Combine("Data", "Input.txt");
            var destination = Path.Combine("Data", "Output.txt");

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (TextReader text = new StreamReader(file))
                {
                    using (FileStream destFile = new FileStream(destination, FileMode.Create))
                    {
                        using (TextWriter writer = new StreamWriter(destFile))
                        {
                            string line = text.ReadLine();
                            int lineNumber = 0;

                            while (line != null)
                            {
                                if (lineNumber % 2 != 0)
                                {
                                    writer.WriteLine(line);
                                }


                                lineNumber++;
                                line = text.ReadLine();
                            }

                        }
                    }                                 
                }
            }
        }
    }
}
