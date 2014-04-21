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
                return Response.AsJson(new Basket());
            };
        }
    }
}