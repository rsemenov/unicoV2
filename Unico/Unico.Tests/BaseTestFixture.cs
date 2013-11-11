using NUnit.Framework;

namespace Unico.Tests
{
    [TestFixture]
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
}