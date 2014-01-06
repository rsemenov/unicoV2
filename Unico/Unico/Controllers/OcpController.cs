using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unico.Data.Entities;
using Unico.Data.Interfaces;

namespace Unico.Controllers
{
    public class OcpController : Controller
    {
        public IRepository<Cartrige> CartrigesRepository { get; set; }
        public IRepository<Printer> PrintersRepository { get; set; }
        public IRepository<OcpProduct> OcpProductsRepository { get; set; }

        // GET: /Ocp/

        public ActionResult Index()
        {
            var products = OcpProductsRepository.FindAll().ToList();

            var cartriges = CartrigesRepository.FindAll();
            var pp = cartriges[0].Printers.ToList();

            var printers = PrintersRepository.FindAll();
            var cc = printers[0].Cartriges.ToList();
            return View();
        }

    }
}
