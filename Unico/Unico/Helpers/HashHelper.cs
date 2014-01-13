using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unico.Helpers
{
    public static class HashHelper
    {        
        public static string GetStringHash(Guid id, int length = 10)
        {
            var num = Hash(id.ToString()) % 10000000000;
            return num.ToString();
        }

        public static Int64 Hash(string str)
        {
            Int64 hash = 0;
            int c, i=0;

            while (i < str.Length)
            {
                c = str[i++];
                hash = c + (hash << 6) + (hash << 16) - hash;
            }

            return Math.Abs(hash);
        }
    }
}