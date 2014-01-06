using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Unico.Data.Enum;

namespace Unico.Models
{
    public class OrderModel
    {
        public const string ACTIVE_ORDER = "Активный";
        public const string DONE_ORDER = "Готово";

        public int OrderId { get; set; }
        public Guid ExternalId { get; set; }
        public Guid AccountId { get; set; }

        [Display(Name = "Номер заказа")]
        public string Number { get; set; }        

        [Display(Name = "Дата оформления")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Дата выполнения")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ClosedOn { get; set; }

        [Display(Name = "Статус")]
        public string Status
        {
            get
            {
                if (ClosedOn == null)
                {
                    return ACTIVE_ORDER;
                }
                return DONE_ORDER;
            }
        }

        public List<OrderItemModel> Items { get; set; }

        [Display(Name = "Всего")]
        public decimal Amount
        {
            get { return Items.Sum(x => x.Amount); }
        }
    }

    public class OrderItemModel
    {
        public Guid ProductId { get; set; }

        [Display(Name = "Товар")]
        public string ProductName { get; set; }
        [Display(Name = "Описание")]
        public string ProductDetails { get; set; }
        [Display(Name = "Количество")]
        public int Count { get; set; }
        [Display(Name = "Цена за ед.")]
        public decimal Price { get; set; }
        [Display(Name = "Тип работ")]
        public WorkType WorkType { get; set; }
        [Display(Name = "Доп. сведения")]
        public string Notes { get; set; }
        [Display(Name = "Статус")]
        public OrderStatus Status { get; set; }
        [Display(Name = "Обновление статуса")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime LastStatusUpdate { get; set; }

        [Display(Name = "Сумма")]
        public decimal Amount  { get { return Count*Price; }}
    }
}