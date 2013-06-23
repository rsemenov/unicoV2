﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            ViewBag.Message = "Измените этот шаблон, чтобы быстро приступить к работе над приложением ASP.NET MVC.";

            //var d = new Department() { Name = "Test", Description = "dfsdfs" };
            //DepartmentRepository.Add(d);

            var dep = DepartmentRepository.FindAll();
            var c = dep[0].Categories[0];
            //CategoriesRepository.Add(c);


            return View();
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
