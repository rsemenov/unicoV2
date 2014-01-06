using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unico.Helpers
{
    public static class HashHelper
    {
        public static string GetStringHash(Guid id, int length=10)
        {
            return id.ToString().Substring(10, length);
        }
    }
}