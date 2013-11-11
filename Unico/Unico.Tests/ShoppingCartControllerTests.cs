using System;
using System.Web;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Unico.Controllers;
using Unico.Data.Entities;
using Unico.Data.Interfaces;

namespace Unico.Tests
{
    public class ShoppingCartControllerTests : BaseTestFixture<ShoppingCartController>
    {
        private LocalValue<Mock<IRepository<CartItem>>> _cartItemsRepositoryMock = 
            new LocalValue<Mock<IRepository<Data.Entities.CartItem>>>(() => new Mock<IRepository<Data.Entities.CartItem>>());

        private LocalValue<Mock<IRepository<Product>>> _productRepositoryMock =
            new LocalValue<Mock<IRepository<Product>>>(() => new Mock<IRepository<Product>>());

       // private LocalValue<Mock<Session>> _productRepositoryMock =
        //    new LocalValue<Mock<IRepository<Product>>>(() => new Mock<IRepository<Product>>());

        public override ShoppingCartController Construct()
        {
            return new ShoppingCartController()
                {
                    CartItemsRepository = _cartItemsRepositoryMock.Value.Object,
                    ProductsRepository = _productRepositoryMock.Value.Object
                    //ControllerContext = new ControllerContext(new HttpContextWrapper(new HttpContext(new HttpRequest("temp","",""), new HttpResponse(null))), )
                };
        }

        [Test]
        public void ProductShouldBeAddedToCartItemsRepository_WhenAddProductCalled()
        {
            Guid productId = Guid.NewGuid();

            var res = Sut.AddProduct(productId, 1, null);

            _cartItemsRepositoryMock.Value.Verify(repo => repo.SaveOrUpdateAll(It.Is<CartItem[]>(arr => arr[0].ProductId == productId)), Times.Once);
        }
    }
}