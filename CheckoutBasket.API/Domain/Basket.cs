using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using CheckoutBasket.API.Events;

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

            // create event
            var basketEvent = new CreateBasketEvent {Id = id};

            // store event in basket event store
            var filename = string.Format("./EventStore/Basket/{0}", id);
            var sterilizer = new XmlSerializer(typeof (List<CreateBasketEvent>));
            var writer = new StreamWriter(filename);
            sterilizer.Serialize(writer,new List<CreateBasketEvent>{basketEvent});
            writer.Close();

            // return new basket
            return new Basket { Id = id };
        }

        private static string GenerateBasketId()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}