using System.Collections.Generic;
using CheckoutBasket.API.Events;

namespace CheckoutBasket.API.Infrastructure
{
    public interface IEventStore
    {
        void Store(ApplicationEvent applicationEvent, string path);

        IList<ApplicationEvent> Retrieve(string path);
    }
}