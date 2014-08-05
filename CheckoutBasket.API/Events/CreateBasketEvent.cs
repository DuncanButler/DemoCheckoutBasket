using System.Xml.Serialization;

namespace CheckoutBasket.API.Events
{
    public class CreateBasketEvent : ApplicationEvent
    {
        public string Id { get; set; } 
    }
}