using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unico.Infrastructure
{
    public static class SessionKeys
    {
        public static string ShoppingCardId = "ShoppingCardId";
    }

    public static class SessionExtensions
    {
        public static Guid GetShoppingCardId(this HttpSessionStateBase session)
        {
            if (session[SessionKeys.ShoppingCardId] == null)
            {
                session[SessionKeys.ShoppingCardId] = Guid.NewGuid();
            }
            return (Guid)session[SessionKeys.ShoppingCardId];
        }
    }
}