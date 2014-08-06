using System;
using System.Collections.Generic;
using System.Linq;
using CheckoutBasket.API.Events;
using CheckoutBasket.API.Infrastructure;

namespace CheckoutBasket.API.Domain
{
    public class Basket
    {
        private IList<object> _items;

        private Basket()
        {
            _items = new List<object>();
        }

        public bool IsEmpty { get { return ! _items.Any(); } }
        public string Id { get; set; }

        public static Basket CreateWithId()
        {
            string id = GenerateBasketId();

            var basketEvent = new CreateBasketEvent {Id = id};

            var filename = string.Format("./EventStore/Basket/{0}", id);
            var eventstore = new EventStore();
            eventstore.Store(basketEvent, filename);

            return new Basket { Id = id };
        }

        public static Basket GetWithId(string basketId)
        {
            var filename = string.Format("./EventStore/Basket/{0}", basketId);
            var eventstore = new EventStore();
            var events = eventstore.Retrieve(filename);

            return new Basket {Id = ((CreateBasketEvent)events[0]).Id};
        }

        private static string GenerateBasketId()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}