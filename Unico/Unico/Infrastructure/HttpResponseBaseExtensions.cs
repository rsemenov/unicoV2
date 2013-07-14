using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Unico.Infrastructure
{
    public static class ObjectExtensions
    {
        public static string ToJson(this Object obj)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(obj.GetType());
            var stream = new MemoryStream();
            ser.WriteObject(stream, obj);
            stream.Position = 0;
            var sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }

        public static T Deserialize<T>(this string jsonText)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            var memStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonText));
            return (T)ser.ReadObject(memStream);
        }
    }

    public static class HttpResponseBaseExtensions
    {
        public static int SetAuthCookie<T>(this HttpResponseBase responseBase, string name, bool rememberMe, T userData)
        {
            /// In order to pickup the settings from config, we create a default cookie and use its values to create a 
            /// new one.
            var cookie = FormsAuthentication.GetAuthCookie(name, rememberMe);
            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration,
                ticket.IsPersistent, userData.ToJson(), ticket.CookiePath);
            var encTicket = FormsAuthentication.Encrypt(newTicket);

            /// Use existing cookie. Could create new one but would have to copy settings over...
            cookie.Value = encTicket;

            responseBase.Cookies.Add(cookie);

            return encTicket.Length;
        }
    }
}