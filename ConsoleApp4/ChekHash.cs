﻿using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Security.Cryptography;

namespace ConsoleApp4
{
    class ChekHash
    {
        public void ProgressEvent(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.Write("{0}    downloaded {1} of {2} bytes. {3} % complete... \r",
        (string)e.UserState,
        e.BytesReceived,
        e.TotalBytesToReceive,
        e.ProgressPercentage);
        }
        public void LoadCompleteEvent(object sender, AsyncCompletedEventArgs e)
        {
            Loader loader = sender as Loader;
            if (loader.component.TypeHashSum == null)
            {
                return;
            }
            string ResultJfCheck = Check(loader.component.TypeHashSum, loader.component.FileOfName, loader.component.HashSum);
            Console.WriteLine("{0} complete hash {1}", loader.component.FileOfName, ResultJfCheck);
        }
        private string Check(string TypeHash, string FileName, string Hash)
        {
            switch (TypeHash)
            {
                case "sha1":
                    if (ChekHashSHA1(FileName, Hash))
                        return "OK";
                    if (!ChekHashSHA1(FileName, Hash))
                        return "faild!";
                    break;
                case "md5":
                    if (ChekHashMD5(FileName, Hash))
                        return "OK";
                    if (!ChekHashMD5(FileName, Hash))
                        return "faild!";
                    break;
                case "sha256":
                    if (ChekHashSHA256(FileName, Hash))
                        return "OK";
                    if (!ChekHashSHA256(FileName, Hash))
                        return "faild!";
                    break;
                default:
                    return "Error chek sum select";
            }
            return "Uniknow error";
        }
        private bool ChekHashMD5(string pathFile, string HashSum)
        {
            bool result;
            using (FileStream fs = File.OpenRead(pathFile))
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] chekSum = md5.ComputeHash(fs);
                string resultSum = BitConverter.ToString(chekSum).Replace("-", string.Empty);
                result = String.Equals(resultSum, HashSum);
            }
            return result;
        }
        private bool ChekHashSHA1(string pathFile, string HashSum)
        {
            bool result;
            using (FileStream fs = File.OpenRead(pathFile))
            using (SHA1 sha1 = new SHA1CryptoServiceProvider())
            {
                byte[] chekSum = sha1.ComputeHash(fs);
                string resultSum = BitConverter.ToString(chekSum).Replace("-", string.Empty);
                result = String.Equals(resultSum, HashSum);
                return result;
            }
        }
        private bool ChekHashSHA256(string pathFile, string HashSum)
        {
            bool result;
            using (FileStream fs = File.OpenRead(pathFile))
            using (SHA256 sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] chekSum = sha256.ComputeHash(fs);
                string resultSum = BitConverter.ToString(chekSum).Replace("-", string.Empty);
                result = String.Equals(resultSum, HashSum);
                return result;
            }
        }
    }
}
