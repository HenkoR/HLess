using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Hless.Data.Tools.HashingTools
{
    public class Sha256
    {
        public static string Hash(string key)
        {
            // Note: Salt can be added later
            byte[] salt = Encoding.ASCII.GetBytes("");

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: key,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }
    }
}
