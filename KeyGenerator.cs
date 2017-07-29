using System;

namespace SafeEncrypt
{
    public class KeyGenerator
    {
        public static string Generate()
        {
            var initialKey = Guid.NewGuid().ToString();
            var sixteenCharKey = initialKey.Substring(0, 16);

            return sixteenCharKey;
        }
    }
}