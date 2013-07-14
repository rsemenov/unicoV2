using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace Unico.Infrastructure
{
    /// <summary>
    /// Binder to pull the UserData out for any actions that may want it.
    /// </summary>
    public class UserDataModelBinder<T> : System.Web.Mvc.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
            System.Web.Mvc.ModelBindingContext bindingContext)
        {
            if (bindingContext.Model != null)
                throw new InvalidOperationException("Cannot update instances");
            if (controllerContext.RequestContext.HttpContext.Request.IsAuthenticated)
            {
                var cookie = controllerContext
                    .RequestContext
                    .HttpContext
                    .Request
                    .Cookies[FormsAuthentication.FormsCookieName];

                if (null == cookie)
                    return null;

                var decrypted = FormsAuthentication.Decrypt(cookie.Value);

                if (!string.IsNullOrEmpty(decrypted.UserData))
                    return decrypted.UserData.Deserialize<T>();
            }
            return null;
        }

        
    }
}