using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Unico.Data.Entities;
using Unico.Data.Interfaces;
using Unico.Models;
using Unico.Data.RepositoryExtensions;
using Unico.Infrastructure;

namespace Unico.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public IRepository<AccountProfile> AccountRepository { get; set; }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {           
            try
            {
                if (ModelState.IsValid)
                {
                    // Some code to validate and check authentication
                    if (!Membership.ValidateUser(model.Email, model.Password))
                    {
                        throw new Exception("Incorrect username or password");
                    }

                    AccountProfile account = AccountRepository.GetByEmail(model.Email);

                    UserData userData = new UserData
                    {
                        Name = account.Name,
                        AccountId = account.ExternalId,
                        Email = account.Email
                    };

                    Response.SetAuthCookie(account.ExternalId.ToString(), model.RememberMe, userData);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Имя пользователя или пароль указаны неверно.");
            }

            model.Password = "";
            return View(model);
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Попытка зарегистрировать пользователя
                try
                {
                    var account = new AccountProfile()
                    {
                        ExternalId = Guid.NewGuid(),
                        Email = model.UserName,
                        Name = model.UserName,
                        Role = Data.Enum.AccountRole.User,
                        Address = "",
                        Phone = ""                        
                    };

                    AccountRepository.RegisterAccount(account, model.Password);

                    return RedirectToAction("Login", "Account");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            // Появление этого сообщения означает наличие ошибки; повторное отображение формы
            return View(model);
        }

    }
}
