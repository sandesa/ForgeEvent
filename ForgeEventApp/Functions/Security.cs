using System.Security.Cryptography;
using System;
using System.Text;

namespace ForgeEventApp.Functions
{
    public class Security
    {
        public static string GenerateSalt()
        {
            byte[] salt = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
        public static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            using(var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashByte = new byte[36];
                Array.Copy(saltBytes, 0, hashByte, 0, 16);
                Array.Copy(hash, 0, hashByte, 16, 20);
                return Convert.ToBase64String(hashByte);
            }
        }


    }

}
