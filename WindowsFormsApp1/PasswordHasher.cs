// PasswordHasher.cs
using System;
using System.Security.Cryptography;

namespace WindowsFormsApp1 // Projenizin namespace'ine dikkat edin!
{
    public class PasswordHasher
    {
        private const int Iterations = 100000;
        private const int SaltSize = 16;
        private const int HashSize = 32;

        public string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPassword(string password, string hashedPasswordFromDb)
        {
            // Login işleminde kullanılacak. Şimdilik sadece metod imzası kalsın.
            // ... (Doğrulama kodu Form 2 için eklenecek)
            byte[] hashBytes = Convert.FromBase64String(hashedPasswordFromDb);
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);
            byte[] storedHash = new byte[HashSize];
            Array.Copy(hashBytes, SaltSize, storedHash, 0, HashSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] newHash = pbkdf2.GetBytes(HashSize);

            bool success = true;
            for (int i = 0; i < HashSize; i++)
            {
                if (storedHash[i] != newHash[i])
                {
                    success = false;
                }
            }
            return success;
        }
    }
}
