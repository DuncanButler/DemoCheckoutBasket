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

            var basketEvent = new CreateBasketEvent {Id = id};

            var filename = string.Format("./EventStore/Basket/{0}", id);
            var sterilizer = new XmlSerializer(typeof (List<ApplicationEvent>));
            var writer = new StreamWriter(filename);
            sterilizer.Serialize(writer,new List<ApplicationEvent>{basketEvent});
            writer.Close();

            return new Basket { Id = id };
        }

        public static Basket GetWithId(string basketId)
        {
            var filename = string.Format("./EventStore/Basket/{0}", basketId);
            var sterilizer = new XmlSerializer(typeof (List<ApplicationEvent>));
            var reader = new StreamReader(filename);
            var events = (List<ApplicationEvent>) sterilizer.Deserialize(reader);
            reader.Close();

            return new Basket {Id = ((CreateBasketEvent)events[0]).Id};
        }

        private static string GenerateBasketId()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}