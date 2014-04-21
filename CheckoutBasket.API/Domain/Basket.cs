using System;
using System.Collections.Generic;
using System.Linq;

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
            return new Basket { Id = GenerateBasketId() };
        }

        private static string GenerateBasketId()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}