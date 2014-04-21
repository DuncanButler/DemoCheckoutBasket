using System.Collections.Generic;
using Nancy;

namespace CheckoutBasket.API
{
    public class BasketHander : NancyModule
    {
        public BasketHander()
        {
            Get["/basket"] = _ =>
            {
                return Response.AsJson(new Basket());
            };
        }
    }
}