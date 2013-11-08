using Gallio.Framework;
using MbUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Controllers;
using Unico.Data.Entities;
using Unico.Data.Interfaces;

namespace Unico.Tests
{
    public class ShoppingCartControllerTests : BaseTestFixture<ShoppingCartController>
    {
        private LocalValue<Mock<IRepository<Data.Entities.CartItem>>> _cartItemsRepositoryMock = 
            new LocalValue<Mock<IRepository<Data.Entities.CartItem>>>(() => new Mock<IRepository<Data.Entities.CartItem>>());

        private LocalValue<Mock<IRepository<Product>>> _productRepositoryMock =
           new LocalValue<Mock<IRepository<Product>>>(() => new Mock<IRepository<Product>>());

        public override ShoppingCartController Construct()
        {
            return new ShoppingCartController()
            {
                CartItemsRepository = _cartItemsRepositoryMock.Value.Object,
                ProductsRepository = _productRepositoryMock.Value.Object                
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

    [TestFixture, Parallelizable(TestScope.All)]
    public abstract class BaseTestFixture<T> where T : class
    {
        private LocalValue<T> _sut;

        public T Sut { get { return _sut.Value; } }

        public BaseTestFixture()
        {
            _sut = new LocalValue<T>(Construct);
        }

        public abstract T Construct();                
    }

    public class LocalValue<T> where T : class
    {
        private Dictionary<string, T> _values = new Dictionary<string, T>();
        private Func<T> _constructor;
        private readonly object _lockObj = new object();

        public LocalValue(Func<T> constructor)
        {
            _constructor = constructor;
        }

        public T Value
        {
            get
            {
                lock (_lockObj)
                {
                    var testId = TestContext.CurrentContext.TestStep.Id;
                    if (!_values.ContainsKey(testId))
                    {
                        _values.Add(testId, _constructor());
                    }
                    return _values[testId];
                }
            }
            set
            {
                lock (_lockObj)
                {
                    var testId = TestContext.CurrentContext.TestStep.Id;
                    _values[testId] = value;
                }
            }
        }


    }

}
