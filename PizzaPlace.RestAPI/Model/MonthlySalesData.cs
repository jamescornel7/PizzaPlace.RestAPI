using System;
using System.Collections.Generic;

namespace PizzaPlace.RestAPI.Model
{
    public class MonthlySalesData
    {
        public string Year { get; set; }
        public string Month {  get; set; }
        public List<PizzaSalesData> PizzaSalesData { get; set; }
        public decimal TotalSales { get; set; }
        

    }

    public class PizzaSalesData
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
