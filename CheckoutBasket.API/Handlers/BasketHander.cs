using System;
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
                Basket basket = Basket.CreateWithId();

                return Response.AsJson(basket);
            };
        }
    }
}