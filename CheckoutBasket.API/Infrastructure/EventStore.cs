using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using CheckoutBasket.API.Events;

namespace CheckoutBasket.API.Infrastructure
{
    public class EventStore : IEventStore
    {
        public void Store(ApplicationEvent applicationEvent, string path)
        {
            var sterilizer = new XmlSerializer(typeof(List<ApplicationEvent>));
            var writer = new StreamWriter(path);
            sterilizer.Serialize(writer, new List<ApplicationEvent> { applicationEvent });
            writer.Close();

        }

        public IList<ApplicationEvent> Retrieve(string path)
        {
            var sterilizer = new XmlSerializer(typeof(List<ApplicationEvent>));
            var reader = new StreamReader(path);
            var events = (List<ApplicationEvent>)sterilizer.Deserialize(reader);
            reader.Close();

            return events;
        }
    }
}