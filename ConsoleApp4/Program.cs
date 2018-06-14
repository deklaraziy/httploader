using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Loader> loaders = new List<Loader>();
            ChekHash chekHash = new ChekHash();
            
            
            string pathInputFile = "input.txt";
            try
            {
                using (StreamReader inread = new StreamReader(pathInputFile))
                {
                    int j = 0;
                    while(!inread.EndOfStream)
                    {
                        string line = inread.ReadLine();
                        if (line.Length != 0)
                        {
                            loaders.Add(new Loader());
                            loaders[j].component.SetAll(line);
                            loaders[j].StartLoad(loaders[j].component.ChkedUrlAdress, loaders[j].component.FileOfName);
                            loaders[j].DownloadFileCompleted += new AsyncCompletedEventHandler(chekHash.LoadCompleteEvent);
                            j++;
                        }
                    }
                    
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("File input.txt not found");
              //  Console.WriteLine(e.Message);
              //  Console.ReadKey();
            }

            foreach (var l in loaders)
            {
                while (l.IsBusy) ;
            }
        }

    }
}
