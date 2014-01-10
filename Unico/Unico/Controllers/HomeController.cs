using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Unico.Data.Entities;
using Unico.Data.Interfaces;

namespace Unico.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<Department> DepartmentRepository { get; set; }
        public IRepository<Category> CategoriesRepository { get; set; }

        
        public ActionResult Index()
        {
            var p = Membership.Provider;
            return View();        
        }

        public ActionResult _Menu()
        {
            var departments = DepartmentRepository.FindAll();
            return PartialView(departments);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Страница описания приложения.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница контактов.";

            return View();
        }
    }
}
