using System.Security.Cryptography;
using System.Text;

namespace Task3
{
    public static class HmacGenerator
    {
        public static string Generate(byte[] key, string message)
        {
            using var hmac = new HMACSHA256(key);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}
