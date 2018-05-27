using System;
using System.IO;
using System.Collections.Generic;


namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DownloadComponent> DObjects = new List<DownloadComponent>();
            
            string pathInputFile = "input.txt";
            try
            {
                using (StreamReader inread = new StreamReader(pathInputFile))
                {
                    while(!inread.EndOfStream)
                    {
                        string line = inread.ReadLine();
                        // Console.WriteLine(line);
                        var parsing = line.Split();
                        DObjects.Add(new DownloadComponent() { AdressUrl = parsing[0], TypeHashSum = parsing[1], HashSum = parsing[2] });
                        
                    }
                 Console.ReadKey();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("File input.txt not found");
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            foreach(var i in DObjects )
            {
                Console.WriteLine(i.AdressUrl);
            }
        }
    }
}
