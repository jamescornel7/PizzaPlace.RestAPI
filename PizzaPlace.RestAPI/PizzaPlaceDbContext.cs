using PizzaPlace.RestAPI.Model;
using PizzaPlace.RestAPI.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace PizzaPlace.RestAPI
{
    public class PizzaPlaceDbContext : DbContext, IPizzaPlaceDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var rootbuilder = builder.Build().AsEnumerable().ToList();
            string connectionString = (rootbuilder.Where(c => c.Key == "ConnectionString").Select(c => c.Value).FirstOrDefault()).ToString();
            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Pizzas> Pizzas { get; set; }
        public DbSet<PizzaTypes> PizzaTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>(en => {
                en.ToTable("order_details", "public");

                en.HasKey(e => e.OrderDetailsId)
                .HasName("order_details_pkey");

                en.Property(e => e.OrderDetailsId)
                .HasColumnType("integer").
                HasColumnName("order_details_id");

                en.Property(e => e.OrderId)
                .HasColumnType("integer").
                HasColumnName("order_id");

                en.Property(e => e.PizzaId)
                .HasColumnType("character varying").
                HasColumnName("pizza_id");

                en.Property(e => e.Quantity)
                .HasColumnType("integer").
                HasColumnName("quantity");
            });

            modelBuilder.Entity<Orders>(en => {
                en.ToTable("orders", "public");

                en.HasKey(e => e.OrderId)
                .HasName("orders_pkey");

                en.Property(e => e.OrderId)
                .HasColumnType("integer").
                HasColumnName("order_id");

                en.Property(e => e.Date)
                .HasColumnType("date").
                HasColumnName("date");

                en.Property(e => e.Time)
                .HasColumnType("time without time zone").
                HasColumnName("time");

            });

            modelBuilder.Entity<Pizzas>(en => {
                en.ToTable("pizzas", "public");

                en.HasKey(e => e.PizzaId)
                .HasName("pizzas_pkey");

                en.Property(e => e.PizzaId)
                .HasColumnType("character varying").
                HasColumnName("pizza_id");

                en.Property(e => e.PizzaTypeId)
                .HasColumnType("character varying").
                HasColumnName("pizza_type_id");

                en.Property(e => e.Size)
                .HasColumnType("character varying").
                HasColumnName("size");

                en.Property(e => e.Price)
                .HasColumnType("numeric").
                HasColumnName("price");
            });

            modelBuilder.Entity<PizzaTypes>(en => {
                en.ToTable("pizza_types", "public");

                en.HasKey(e => e.PizzaTypeId)
                .HasName("pizza_types_pkey");

                en.Property(e => e.PizzaTypeId)
                .HasColumnType("character varying").
                HasColumnName("pizza_type_id");

                en.Property(e => e.Name)
                .HasColumnType("character varying").
                HasColumnName("name");

                en.Property(e => e.Category)
                .HasColumnType("character varying").
                HasColumnName("category");

                en.Property(e => e.Ingredients)
                .HasColumnType("character varying").
                HasColumnName("ingredients");
            });
        }

        void IDisposable.Dispose() {
            base.Dispose();
        }
    }
}
