using System.Xml.Serialization;

namespace CheckoutBasket.API.Events
{
    [XmlInclude(typeof(CreateBasketEvent))]
    public class ApplicationEvent
    {
    }
}