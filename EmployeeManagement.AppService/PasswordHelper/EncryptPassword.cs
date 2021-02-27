using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeManagement.AppService.PasswordHelper
{
    public static class EncryptPassword
    {
        public static string CreateSalt(int size)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static string GenerateSHAHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed shaString = new SHA256Managed();
            byte[] hash = shaString.ComputeHash(bytes);

            return ConvertByteArrayToHexString(hash);

        }

        public static string ConvertByteArrayToHexString(byte[] btyes)
        {
            
                StringBuilder hex = new StringBuilder(btyes.Length * 2);
                foreach (byte b in btyes)
                    hex.AppendFormat("{0:x2}", b);
                return hex.ToString();
            
        }
    }
}
