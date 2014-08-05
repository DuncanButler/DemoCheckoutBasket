using CheckoutBasket.API.Domain;
using Nancy;

namespace CheckoutBasket.API.Handlers
{
    public class BasketHander : NancyModule
    {
        public BasketHander()
        {
            Get["/basket/{id?}"] = _ =>
            {
                Basket basket;
                
                if (_.id == null)
                    basket = Basket.CreateWithId();
                else
                    basket = Basket.GetWithId(_.id);
                
                return Response.AsJson(basket);
            };
        }
    }
}