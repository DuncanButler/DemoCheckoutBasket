using System.Linq;
using CheckoutBasket.API;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using Shouldly;

namespace CheckoutBasket.Specifications
{
    public class When_calling_the_basket_api_without_an_id : BddBase
    {
        private Basket _basket;
        private Browser _browser;

        protected override void Given()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            _browser = new Browser(bootstrapper);
        }

        protected override void When()
        {
            var response = _browser.Get("/basket");

            _basket = response.Body.DeserializeJson<Basket>();
        }

        [Test]
        public void Then_an_empty_basket_is_returned()
        {
            _basket.IsEmpty.ShouldBe(true);           
        }
    }
}