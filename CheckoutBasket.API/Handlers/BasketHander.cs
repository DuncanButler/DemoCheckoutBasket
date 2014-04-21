using CheckoutBasket.API.Domain;
using Nancy;

namespace CheckoutBasket.API.Handlers
{
    public class BasketHander : NancyModule
    {
        public BasketHander()
        {
            Get["/basket"] = _ =>
            {
                var basket = Basket.CreateWithId();

                return Response.AsJson(basket);
            };
        }
    }
}