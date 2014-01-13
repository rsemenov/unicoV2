using System;
using System.Collections.Generic;
using System.ComponentModel;
using Unico.Data.Entities;
using Unico.Data.Enum;

namespace Unico.Models
{
    public class OcpSelectModel
    {
        public List<Brand> Brands { get; set; }
        public int SelectedBrand { get; set; }
        public List<Printer> Printers { get; set; }
        public Printer SelectedPrinter { get; set; }
        public List<Cartrige> Cartriges { get; set; }
        public Cartrige SelectedCartrige { get; set; }

        public List<OcpProduct> OcpProducts { get; set; }
    }

    public class ProductModel
    {
        public int ProductId { get; set; }
        public Guid ExternalId { get; set; }
        public Brand Brand { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DisplayName("Картинка")]
        public string Image { get; set; }
        [DisplayName("Наличие")]
        public ProductAvailability Availability { get; set; }
        [DisplayName("Картридж")]
        public string Cartridge { get; set; }

        public IList<Cartrige> Cartriges { get; set; }
    }

    public class OcpProductModel : ProductModel
    {
        [DisplayName("Ключ")]
        public string Key { get; set; }
        [DisplayName("Цвет")]
        public string Color { get; set; }
        [DisplayName("Объем")]
        public string Weight { get; set; }
    }
}