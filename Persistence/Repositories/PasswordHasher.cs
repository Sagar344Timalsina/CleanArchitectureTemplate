
using Domain.Interfaces;
using ServiceLayer.Wrapper;
using System.Security.Cryptography;

namespace Persistence.Repositories
{
    public class PasswordHasher : IPasswordHasher
    {
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;



        public string HashPassword(string password)
        {
            //try
            //{
            //    byte[] salt = RandomNumberGenerator.GetBytes(keySize);
            //    var hash = Rfc2898DeriveBytes.Pbkdf2(
            //        Encoding.UTF8.GetBytes(password),
            //    salt,
            //    iterations,
            //        hashAlgorithm,
            //        keySize
            //        );
            //    return Convert.ToHexString(hash);
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                bool verified = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                return verified;
            }
            catch(Exception ex)
            {
                throw new Exception("Invalid Credentials!!!!");
            }
        }
    }
}
