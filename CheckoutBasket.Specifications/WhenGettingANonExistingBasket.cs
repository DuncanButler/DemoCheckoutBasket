using System;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using Shouldly;

namespace CheckoutBasket.Specifications
{
    public class WhenGettingANonExistingBasket : BddBase
    {
        private string _basketId;
        private Browser _browser;
        private BrowserResponse _response;

        protected override void Given()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            _browser = new Browser(bootstrapper);

            _basketId = Guid.NewGuid().ToString().Replace("-", ""); 
        }

        protected override void When()
        {
            _response = _browser.Get(string.Format("/basket/{0}", _basketId));
        }

        [Test]
        public void then_the_response_should_be_404_not_found()
        {
            _response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }
    }
}