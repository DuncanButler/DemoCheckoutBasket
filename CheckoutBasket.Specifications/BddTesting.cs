using NUnit.Framework;

namespace CheckoutBasket.Specifications
{
    [TestFixture]
    public abstract class BddBase
    {
        [SetUp]
        public void Setup()
        {
            Given();

            When();
        }

        protected abstract void Given();

        protected abstract void When();
    }
}