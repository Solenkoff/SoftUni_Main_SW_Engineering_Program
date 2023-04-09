using System;
using System.IO;

namespace _06v2_Folder_Size__RecursiveDirectories_
{
    class Program
    {
        static void Main(string[] args)
        {

            string folderPath = Console.ReadLine();
            Console.WriteLine(ScanFolderRecursively(folderPath, 0));

        }


        static double ScanFolderRecursively(string folderPath, int identation)
        {
           
            var files = Directory.GetFiles(folderPath);

            double fileSizes = 0;

            var directories = Directory.GetDirectories(folderPath);

            foreach (var directory in directories)
            {
                fileSizes += ScanFolderRecursively(directory, identation + 4);
            }

            foreach (var filePath in files)
            {
                FileInfo file = new FileInfo(filePath);

                Console.WriteLine($"{new string(' ', identation)}{file.FullName}");
              
                fileSizes += file.Length;
            }
      
            return  fileSizes / 1024.0 / 1024.0;
        }
    }
}
