using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Unico.Data.Entities;
using Unico.Data.Interfaces;
using Unico.Models;

namespace Unico.Controllers
{
    public class OcpController : Controller
    {
        public IRepository<Cartrige> CartrigesRepository { get; set; }
        public IRepository<Printer> PrintersRepository { get; set; }
        public IRepository<OcpProduct> OcpProductsRepository { get; set; }
        public IRepository<Brand> BrandsRepository { get; set; }

        // GET: /Ocp/

        public ActionResult Index()
        {
            var brands = BrandsRepository.FindAll(b => b.Name != "OCP").ToList();
            var model = new OcpSelectModel()
                {
                    Brands = brands
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult GetPrinters(int selectedBrand)
        {
            var brand = BrandsRepository.Find(b => b.BrandId == selectedBrand);

            var printers = PrintersRepository.FindAll(p => p.Brand == brand).ToList();
           
            var json = Json(printers.Select(p=>new{PrinterId=p.PrinterId, Name=p.Name}).ToList());

            return json;
        }

        [HttpPost]
        public ActionResult GetCartriges(int selectedPrinter)
        {
            var printer = PrintersRepository.Find(b => b.PrinterId == selectedPrinter);

            var json = Json(printer.Cartriges.Select(c => new { c.CartrigeId, c.Name }).ToList());

            return json;
        }

        [HttpPost]
        public ActionResult GetPrintersByCartrige(int selectedCartrige)
        {
            var cart = CartrigesRepository.Find(b => b.CartrigeId == selectedCartrige);

            var json = Json(cart.Printers.Select(c => new { c.PrinterId, c.Name }).ToList());

            return json;
        }

        public PartialViewResult OcpProducts(int selectedPrinter, int selectedCartrige)
        {
            var ocpProducts = new List<OcpProductModel>();

            if (selectedCartrige == -1)
            {
                var printer = PrintersRepository.Find(b => b.PrinterId == selectedPrinter);

                if (printer != null && printer.Cartriges != null)
                {
                    foreach (var cartrige in printer.Cartriges)
                    {
                        var cart = CartrigesRepository.Find(b => b.CartrigeId == cartrige.CartrigeId);
                        if (cart.Products != null)
                        {
                            foreach (var p in cart.Products)
                            {
                                var ocp = OcpProductsRepository.Find(pr => pr.ExternalId == p.ExternalId);
                                if (ocp != null && ocpProducts.All(pr => pr.ExternalId != ocp.ExternalId))
                                {
                                    ocpProducts.Add(Mapper.Map<OcpProductModel>(ocp));
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                var cart = CartrigesRepository.Find(b => b.CartrigeId == selectedCartrige);
                if (cart!=null & cart.Products != null)
                {
                    foreach (var p in cart.Products)
                    {
                        var ocp = OcpProductsRepository.Find(pr => pr.ExternalId == p.ExternalId);
                        if (ocp != null)
                        {
                            ocpProducts.Add(Mapper.Map<OcpProductModel>(ocp));
                        }
                    }
                }
            }

            return PartialView("OcpProducts", ocpProducts);
        }       
    }
}
