using System.Collections.Generic;
using System.Linq;

namespace CheckoutBasket.API
{
    public class Basket
    {
        public IList<object> Items { get; set; }

        public bool IsEmpty { get { return ! Items.Any(); } }
    }
}