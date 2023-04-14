using System;
using System.IO;
using System.IO.Compression;

namespace _06_Zip_And_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
          
            ZipFile.CreateFromDirectory(@"D:\01_Source", @"D:\02_Create\MyZipFile.zip");
            ZipFile.ExtractToDirectory(@"D:\02_Create\MyZipFile.zip", @"D:\03_Extarcted");

        }  
    }
}
