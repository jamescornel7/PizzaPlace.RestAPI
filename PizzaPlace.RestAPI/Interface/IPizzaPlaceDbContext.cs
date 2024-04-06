using PizzaPlace.RestAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPlace.RestAPI.Interface
{
    public interface IPizzaPlaceDbContext : IDisposable
    {
        DbSet<OrderDetails> OrderDetails { get; set; }
        DbSet<Orders> Orders { get; set; }
        DbSet<Pizzas> Pizzas { get; set; }
        DbSet<PizzaTypes> PizzaTypes { get; set; }

        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        void Dispose();
    }
}
