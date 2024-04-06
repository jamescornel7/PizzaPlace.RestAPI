using System;
using System.Collections.Generic;

namespace PizzaPlace.RestAPI.Model
{
    public partial class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int OrderId{ get; set; }
        public string PizzaId { get; set; }
        public int Quantity { get; set; }
    }
}
