using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using MbUnit.Framework;
using Moq;
using Unico.Controllers;
using Unico.Data.Entities;
using Unico.Data.Enum;
using Unico.Data.Interfaces;
using Unico.Infrastructure;
using Unico.Models;
using CartItem = Unico.Data.Entities.CartItem;

namespace Unico.Tests
{
    [TestFixture, Parallelizable(TestScope.Self)]
    public class ShoppingCartControllerTests : BaseTestFixture<ShoppingCartController>
    {
        private LocalValue<Mock<IRepository<CartItem>>> _cartItemsRepositoryMock = 
            new LocalValue<Mock<IRepository<CartItem>>>(() => new Mock<IRepository<CartItem>>());

        private LocalValue<Mock<IRepository<Product>>> _productRepositoryMock =
            new LocalValue<Mock<IRepository<Product>>>(() => new Mock<IRepository<Product>>());

        private LocalValue<Mock<HttpSessionStateBase>> _sessionMock =
            new LocalValue<Mock<HttpSessionStateBase>>(() => new Mock<HttpSessionStateBase>());

        private LocalValue<Mock<HttpContextBase>> _httpContextMock =
            new LocalValue<Mock<HttpContextBase>>(() => new Mock<HttpContextBase>());

        private static Guid _sessionId = Guid.NewGuid();
        private static Guid _productId = Guid.NewGuid();

        private LocalValue<IList<CartItem>> _cartItems = new LocalValue<IList<CartItem>>(() => new List<CartItem>() { 
                new CartItem() { CartItemId = 0, ProductId = _productId, OrderId = _sessionId}, 
                new CartItem() { CartItemId = 1, ProductId = Guid.NewGuid(), OrderId = _sessionId }, 
                new CartItem() { CartItemId = 2, ProductId = Guid.NewGuid(), OrderId = _sessionId }});

        public override ShoppingCartController Construct()
        {
            _sessionMock.Value.Setup(s => s[It.Is<string>(k=> k == SessionKeys.ShoppingCardId)]).Returns(_sessionId);
            _httpContextMock.Value.Setup(x => x.Session).Returns(_sessionMock.Value.Object);
            var controllerCtx = new ControllerContext();
            controllerCtx.HttpContext = _httpContextMock.Value.Object;

            SetupItemsRepo();

            return new ShoppingCartController()
                {
                    CartItemsRepository = _cartItemsRepositoryMock.Value.Object,
                    ProductsRepository = _productRepositoryMock.Value.Object,
                    ControllerContext = controllerCtx
                };
        }

        private void SetupItemsRepo()
        {
            _cartItemsRepositoryMock.Value.Setup(repo => repo.FindAll(It.IsAny<Expression<Func<CartItem, bool>>>()))
           .Returns(_cartItems.Value);

            _cartItemsRepositoryMock.Value.Setup(repo => repo.SaveOrUpdateAll(It.IsAny<CartItem[]>()))
            .Callback((CartItem[] c) => _cartItems.Value.Add(c[0]));

            _cartItemsRepositoryMock.Value.Setup(repo => repo.Delete(It.IsAny<CartItem>()))
            .Callback((CartItem item) => _cartItems.Value.Remove(item));

            _cartItemsRepositoryMock.Value.Setup(repo => repo.Find(It.IsAny<Expression<Func<CartItem, bool>>>()))
            .Returns(_cartItems.Value[0]);

            _productRepositoryMock.Value.Setup(repo => repo.Find(It.IsAny<Expression<Func<Product, bool>>>()))
            .Returns(new Product()
            {
                ProductId = 1,
                Availability = ProductAvailability.Available,
                Brand = new Brand() { BrandId = 1, Name = "IBM" },
                Name = "name",
                Price = 1000,
            });
        }

        [Test(Order = 1)]
        public void ShoppingCartWidget_ShouldReturnEmptyModel_WhenUserDataIsNull()
        {
            var res = Sut.ShoppingCartWidget(null);

            var model = (ShoppingCartWidgetModel)res.Model;
            Assert.IsTrue(model.Count == 0);
        }

        [Test(Order = 2)]
        public void ItemShouldBeDeleted_WhenDeleteItemMethodCalled()
        {
            var res = Sut.DeleteItem(_cartItems.Value[0].ProductId, new UserData());

            var model = (ShoppingCartModel)res.Model;
            Assert.IsTrue(model.CartItems.Count == 2);
        }

        [Test(Order = 3)]
        public void SetCount_ShouldDeleteProductCorrectly_WhenCountIsZero()
        {
            var res = Sut.SetCount(_productId, 0, new UserData());

            var model = (ShoppingCartModel)res.Model;
            Assert.IsTrue(model.CartItems.Count == 2);
        }

        [Test(Order = 4)]
        public void ProductShouldBeAddedToCartItemsRepository_WhenAddProductCalled()
        {
            Sut.AddProduct(_productId, 1, null);

            _cartItemsRepositoryMock.Value.Verify(repo => 
                repo.SaveOrUpdateAll(It.Is<CartItem[]>(arr => arr[0].ProductId == _productId)), Times.Once);
        }

        [Test(Order = 6)]
        public void CorrectItemsCountShouldBeReturned_WhenAddProductCalled()
        {
            var res = Sut.AddProduct(_productId, 1, new UserData());

            var model = (ShoppingCartWidgetModel)res.Model;
            Assert.IsTrue(model.Count == 4);
        }
        
        [Test(Order = 5)]
        public void SetCount_ShouldUpdateCountCorrectly_WhenCountIsSet()
        {
            var res = Sut.SetCount(_productId, 4, new UserData());

            var model = (ShoppingCartModel)res.Model;
            Assert.IsTrue(model.CartItems[0].Count == 4);
        }
    }
}