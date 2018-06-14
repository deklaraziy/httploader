using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace ConsoleApp4
{
    class DownloadComponent
    {
        public DownloadComponent (string str)
        {
            var parsing = str.Split();   
            AdressUrl = parsing[0];
            TypeHashSum = parsing[1].ToLower();
            HashSum = parsing[2].ToUpper();
            FileOfName = Path.GetFileName(AdressUrl);
            ChkedUrlAdress = new Uri(AdressUrl);
        }
        public DownloadComponent()
        {

        }
        public void SetAll(string str)
        {
            var parsing = str.Split();
            AdressUrl = parsing[0];
            TypeHashSum = parsing[1].ToLower();
            HashSum = parsing[2].ToUpper();
            FileOfName = Path.GetFileName(AdressUrl);
            ChkedUrlAdress = new Uri(AdressUrl);
        }
        public string AdressUrl { get; private set; }
        public string TypeHashSum { get; private set; }
        public string HashSum { get; private set; }
        public string FileOfName { get; private set; }
        public Uri ChkedUrlAdress { get; private set; }
    }
}
