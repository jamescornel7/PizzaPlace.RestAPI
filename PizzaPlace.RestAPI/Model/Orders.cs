using System;
using System.Collections.Generic;

namespace PizzaPlace.RestAPI.Model
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public DateOnly Date {  get; set; }
        public TimeOnly Time { get; set; }
    }
}
