using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Unico.Models
{
    public class ShoppingCartModel
    {
        public IList<CartItem> CartItems { get; set; }

        [Display(Name = "К оплате")]
        public decimal TotalAmount { get { return CartItems.Sum(c => c.Amount); } }
    }

    public class CartItem
    {
        public Guid ProductId { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Бренд")]
        public string Brand { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Количество")]
        public int Count { get; set; }

        [Display(Name = "Сума")]
        public decimal Amount { get { return Count * Price; } }
    }
}