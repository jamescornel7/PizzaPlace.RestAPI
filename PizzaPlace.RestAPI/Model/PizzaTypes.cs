using System;
using System.Collections.Generic;

namespace PizzaPlace.RestAPI.Model
{
    public partial class PizzaTypes
    {
        public string PizzaTypeId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }
    }
}
