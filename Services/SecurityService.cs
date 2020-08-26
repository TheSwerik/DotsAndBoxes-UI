using System;
using System.Security.Cryptography;

namespace UI.Services
{
    public static class SecurityService
    {
        /// <summary>Hashes and Salts your password.</summary>
        /// <param name="password"></param>
        /// <returns>The Hashed Password</returns>
        public static string HashPassword(string password)
        {
            Console.WriteLine($"The Plain-Text Password: {password}");

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[20]);
            Console.WriteLine($"The Salt: {Convert.ToBase64String(salt)}");

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            var hash = pbkdf2.GetBytes(20);
            Console.WriteLine($"The Hash: {Convert.ToBase64String(hash)}");

            var hashBytes = new byte[40];
            Array.Copy(salt, 0, hashBytes, 0, 20);
            Array.Copy(hash, 0, hashBytes, 20, 20);
            Console.WriteLine($"The Salted and Hashed Password: {Convert.ToBase64String(hashBytes)}");

            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>Hashes your password with a given salt.</summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns>The Hashed Password</returns>
        public static string HashPasswordWithGivenSalt(string password)
        {
            Console.WriteLine($"The Plain-Text Password: {password}");

            //TODO split Password and salt
            var saltBytes = Convert.FromBase64String(password.Substring(0,27));

            var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hash = pbkdf2.GetBytes(20);
            Console.WriteLine($"The Hash: {Convert.ToBase64String(hash)}");

            var hashBytes = new byte[40];
            Array.Copy(saltBytes, 0, hashBytes, 0, 20);
            Array.Copy(hash, 0, hashBytes, 20, 20);
            Console.WriteLine($"The Salted and Hashed Password: {Convert.ToBase64String(hashBytes)}");

            return Convert.ToBase64String(hashBytes);
        }

        public static string ConvertPasswordToSalt(string password)
        {
            return password.Substring(0, 26) + '=';
        }
    }
}