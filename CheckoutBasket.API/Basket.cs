using System.Collections.Generic;
using System.Linq;

namespace CheckoutBasket.API
{
    public class Basket
    {
        private IList<object> _items;
 
        public Basket()
        {
            _items = new List<object>();
        }

        public bool IsEmpty { get { return ! _items.Any(); } }
    }
}