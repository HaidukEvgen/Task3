using System.Security.Cryptography;

namespace Task3
{
    public static class KeyGenerator
    {
        public static byte[] Generate()
        {
            using var rng = RandomNumberGenerator.Create();
            var key = new byte[32];
            rng.GetBytes(key);
            return key;
        }
    }
}
