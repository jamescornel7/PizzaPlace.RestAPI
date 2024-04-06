using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

using PizzaPlace.RestAPI.Model;
using PizzaPlace.RestAPI.Interface;

namespace PizzaPlace.RestAPI.Repository
{
    public class PizzaPlaceRepository
    {
        #region OrderDetails
        public List<OrderDetails> GetOrderDetailsList()
        {
            using (PizzaPlaceDbContext context = new PizzaPlaceDbContext())
            {

                var orderDetails = context.OrderDetails.ToList();
                return orderDetails;
            }
        }

        public List<OrderDetails> GetSpecificOrderDetails(int id)
        {
            using (PizzaPlaceDbContext context = new PizzaPlaceDbContext())
            {
                var orderDetails = context.OrderDetails.Where(od => od.OrderId == id).ToList();
                return orderDetails;
            }
        }
        #endregion

        #region Orders
        public List<Orders> GetOrdersList()
        {
            using (PizzaPlaceDbContext context = new PizzaPlaceDbContext())
            {

                var orders = context.Orders.ToList();
                return orders;
            }
        }

        public List<Orders> GetSpecificOrders(int id)
        {
            using (PizzaPlaceDbContext context = new PizzaPlaceDbContext())
            {
                var orders = context.Orders.Where(od => od.OrderId == id).ToList();
                return orders;
            }
        }
        #endregion

        #region Pizzas
        public List<Pizzas> GetPizzasList()
        {
            using(PizzaPlaceDbContext context = new PizzaPlaceDbContext())
            {

                var pizzas = context.Pizzas.ToList();
                return pizzas;
            }
        }

        public List<Pizzas> GetSpecificPizzas(string id)
        {
            using (PizzaPlaceDbContext context = new PizzaPlaceDbContext())
            {

                var pizzas = context.Pizzas.Where(p => p.PizzaTypeId == id).ToList();
                return pizzas;
            }
        }
        #endregion

        #region PizzaTypes
        public List<PizzaTypes> GetPizzaTypesList()
        {
            using (PizzaPlaceDbContext context = new PizzaPlaceDbContext())
            {

                var pizzaTypes = context.PizzaTypes.ToList();
                return pizzaTypes;
            }
        }

        public List<PizzaTypes> GetPizzaTypesByCategory(string category)
        {
            using (PizzaPlaceDbContext context = new PizzaPlaceDbContext())
            {

                var pizzaTypes = context.PizzaTypes.Where(pt => pt.Category == category).ToList();
                return pizzaTypes;
            }
        }
        #endregion

        #region business logics
        public List<MonthlySalesData> GetMonthlySalesData()
        {
            using (PizzaPlaceDbContext context = new PizzaPlaceDbContext())
            {
                var ordersByMonth = context.Orders.GroupBy(x => new { x.Date.Year, x.Date.Month });

                var monthlySales = from od in context.OrderDetails
                                   join o in context.Orders on od.OrderId equals o.OrderId
                                   join pz in context.Pizzas on od.PizzaId equals pz.PizzaId
                                   join pzt in context.PizzaTypes on pz.PizzaTypeId equals pzt.PizzaTypeId
                                   select new 
                                   {
                                       OrderId = o.OrderId,
                                       OrderDetailsId = od.OrderDetailsId,
                                       Name = pzt.Name,
                                       Price = pz.Price * od.Quantity,
                                       Month = o.Date.Month,
                                       Year = o.Date.Year,

                                       
                                   };
                var sales = from ms in monthlySales
                            group ms
                            by new
                            {
                                ms.Name,
                                ms.Month,
                                ms.Year,
                                ms.Price,
                            } into ss
                            select new
                            {
                                Name = ss.Key.Name,
                                Month = ss.Key.Month,
                                Year = ss.Key.Year,
                                Price = ss.Key.Price,
                            };

                List<MonthlySalesData> list = new List<MonthlySalesData>();
                for (int i = 1; i <= 12; i++)
                {
                    var thisMonthsReport = sales.Where(ms => ms.Month == i).ToList();
                    MonthlySalesData data = new MonthlySalesData();
                    data.Month = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[i];
                    data.Year = thisMonthsReport.Select(x => x.Year).FirstOrDefault().ToString();
                    data.PizzaSalesData = new List<PizzaSalesData>();
                    foreach (var item in thisMonthsReport)
                    {
                        data.PizzaSalesData.Add(new PizzaSalesData() { Name = item.Name, Price = item.Price });
                    }
                    if (data.PizzaSalesData.Count() > 0)
                    {
                        data.PizzaSalesData = (from sd in data.PizzaSalesData
                                              group sd by sd.Name into s
                                              select new PizzaSalesData()
                                              {
                                                  Name = s.Key,
                                                  Price = s.Sum(x => x.Price),
                                              }).ToList();
                    }

                    data.TotalSales = data.PizzaSalesData.Sum(x => x.Price);

                    list.Add(data);

                }

                return list;
            }
        }
        #endregion
    }
}
