using System;
using System.IO;
using System.Security.Cryptography;

namespace ConsoleApp4
{
    class ChekHash
    {
        public string Check(string TypeHash, string FileName, string Hash)
        {
            switch (TypeHash)
            {
                case "sha1":
                    if (ChekHashSHA1(FileName, Hash))
                        return "Chek hash sum sucsess!";
                    if (!ChekHashSHA1(FileName, Hash))
                        return "Chek hash sum faild!";
                    break;
                case "md5":
                    if (ChekHashMD5(FileName, Hash))
                        return "Chek hash sum sucsess!";
                    if (!ChekHashMD5(FileName, Hash))
                        return "Chek hash sum faild!";
                    break;
                case "sha256":
                    if (ChekHashSHA256(FileName, Hash))
                        return "Chek hash sum sucsess!";
                    if (!ChekHashSHA256(FileName, Hash))
                        return "Chek hash sum faild!";
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
