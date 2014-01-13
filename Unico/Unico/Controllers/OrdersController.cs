using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unico.Data.Entities;
using Unico.Data.Enum;
using Unico.Data.Interfaces;
using Unico.Email;
using Unico.Helpers;
using Unico.Infrastructure;
using Unico.Models;

namespace Unico.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        public IRepository<Data.Entities.CartItem> CartItemsRepository { get; set; }
        public IRepository<Order> OrdersRepository { get; set; }
        public IRepository<ProductOrder> ProductOrderRepository { get; set; }
        public IRepository<Product> ProductsRepository { get; set; }
        public IEmailSender EmailSender { get; set; }

        //
        // GET: /Orders/

        public ActionResult Index(UserData userData)
        {
            if (userData == null)
            {
                RedirectToAction("Index", "Home");
            }

            var orders = OrdersRepository.FindAll(ord => ord.AccountId == userData.AccountId).ToList()
                .OrderByDescending(ord=>ord.CreatedOn).Select(ord=> Mapper.Map<OrderModel>(ord));
            return View(orders);
        }

        [HttpPost]
        public ActionResult CreateOrder(UserData userData)
        {
            if (userData == null)
            {
                return RedirectToAction("Index", "ShoppingCart", userData);
            }

            var orderId = Session.GetShoppingCardId();
            var cartItems = CartItemsRepository.FindAll(c => c.OrderId == orderId).ToList();
            if (cartItems.Count > 0)
            {
                Session.NewShoppingCardId();

                OrdersRepository.SaveOrUpdateAll(new Order()
                {
                        AccountId = userData.AccountId,
                        Number = HashHelper.GetStringHash(orderId),
                        ExternalId = orderId,
                        CreatedOn = DateTime.UtcNow
                });

                foreach (var cartItem in cartItems)
                {
                    var product = ProductsRepository.Find(p => p.ExternalId == cartItem.ProductId);
                    if (product != null)
                    {
                        ProductOrderRepository.SaveOrUpdateAll(new ProductOrder()
                            {
                                OrderId = orderId,
                                ProductId = cartItem.ProductId,
                                Count = cartItem.Count,
                                Price = product.Price,
                                LastStatusUpdate = DateTime.UtcNow,
                                Status = OrderStatus.New,
                                WorkType = WorkType.Sell //TODO! 
                            });
                    }
                }

                var orderModel = GenerateOrderModel(orderId, userData);
                EmailSender.Send(userData.AccountId, EmailTypeEnum.OrderConfirmation, orderModel);
                EmailSender.SendInternal(userData.AccountId, EmailTypeEnum.NewOrderCreated, orderModel);
                
                return RedirectToAction("Index", userData);
            }

            return RedirectToAction("Index", "ShoppingCart", userData);
        }

        public ActionResult Details(Guid? orderId, UserData userData)
        {
            var orderModel = GenerateOrderModel(orderId, userData);
            if (orderModel == null)
            {
                return RedirectToAction("Index", userData);
            }
            return View(orderModel);
        }

        private OrderModel GenerateOrderModel(Guid? orderId, UserData userData)
        {
            var order = OrdersRepository.Find(ord => ord.AccountId == userData.AccountId && ord.ExternalId == orderId);

            if (order == null)
            {
                return null;
            }

            var orderModel = Mapper.Map<OrderModel>(order);

            var orderItems = ProductOrderRepository.FindAll(item => item.OrderId == orderId).ToList()
                .Select(item =>
                {
                    var model = Mapper.Map<OrderItemModel>(item);
                    var prod = ProductsRepository.Find(p => p.ExternalId == item.ProductId);
                    if (prod != null)
                    {
                        model.ProductName = prod.Name;
                        model.ProductDetails = prod.Description;
                    }
                    return model;
                }).ToList();

            orderModel.Items = orderItems;
            return orderModel;
        }
        
    }
}
