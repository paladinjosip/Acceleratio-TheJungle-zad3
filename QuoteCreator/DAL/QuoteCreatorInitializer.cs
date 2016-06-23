using QuoteCreator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuoteCreator.DAL
{
    public class QuoteCreatorInitializer : DropCreateDatabaseIfModelChanges<QuoteCreatorContext>
    {
        //Seeding database with some data
        protected override void Seed(QuoteCreatorContext context)
        {
            var customers = new List<Customer>
            {
                new Customer { FirstName="Josip", LastName = "Paladin", Email = "jp@jp.jp", Country="Croatia", OIB = "12345678901"},
                new Customer { FirstName="Darko", LastName = "Rubic", Email = "dr@dr.dr", Country="Croatia", OIB = "12323428901"},
                new Customer { FirstName="Domjan", LastName = "Baric", Email = "db@db.db", Country="Croatia", OIB = "32135678901"}

            };
            customers.ForEach(p => context.Customers.Add(p));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product {Name="Laser", Price=25.20m},
                new Product {Name="Gun", Price=125.20m},
                new Product {Name="Car", Price=1250.00m},
                new Product {Name="Bike", Price=210.00m},
                new Product {Name="Flower", Price=210.00m}
            };

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

            var quotes = new List<Quote>
            {
                new Quote {Customer = new Customer(), QuoteProducts = new List<QuoteProduct>() },
                new Quote {Customer = new Customer(), QuoteProducts = new List<QuoteProduct>() },
                new Quote {Customer = new Customer(), QuoteProducts = new List<QuoteProduct>() }
            };

            quotes[0].Customer = customers[0];
            quotes[1].Customer = customers[1];
            quotes[2].Customer = customers[2];

            quotes[0].QuoteProducts.Add(new QuoteProduct { Product = products[0], Quantity = 1 });
            quotes[0].QuoteProducts.Add(new QuoteProduct { Product = products[1], Quantity = 1 });

            quotes[1].QuoteProducts.Add(new QuoteProduct { Product = products[4], Quantity = 3 });

            quotes[2].QuoteProducts.Add(new QuoteProduct { Product = products[2], Quantity = 1 });
            quotes[2].QuoteProducts.Add(new QuoteProduct { Product = products[3], Quantity = 2 });


            quotes.ForEach(p => context.Quotes.Add(p));
            context.SaveChanges();
        }
    }
}