using System;
using System.IO;

namespace _04_Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("Data", "copyMe.png");
            var outputPath = Path.Combine("Data", "NewFile.png");

            using (FileStream reader = new FileStream(path, FileMode.Open))
            {
                using (FileStream writer = new FileStream(outputPath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (reader.CanRead)
                    {
                        int bytesRead = reader.Read(buffer, 0, buffer.Length);

                        if(bytesRead == 0)
                        {
                            break;
                        }
                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }

        }
    }
}
