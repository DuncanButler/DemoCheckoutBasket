using CheckoutBasket.API.Domain;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using Shouldly;

namespace CheckoutBasket.Specifications
{
    public class WhenGettingAnExistingBasket : BddBase
    {
        private Browser _browser;
        private Basket _basket;
        private string _basketId;

        protected override void Given()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            _browser = new Browser(bootstrapper);

            var response = _browser.Get("/basket");

            var basket = response.Body.DeserializeJson<Basket>();
            _basketId = basket.Id;
        }

        protected override void When()
        {
            var response = _browser.Get(string.Format("/basket/{0}", _basketId));

            _basket = response.Body.DeserializeJson<Basket>();
        }

        [Test]
        public void The_returned_basket_id_is_the_expected_basket_id()
        {
            _basket.Id.ShouldBe(_basketId);
        }
    }
}