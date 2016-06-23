using QuoteCreator.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuoteCreator.Models
{
    public class QuoteRepository
    {
        public IEnumerable<Quote> GetAll()
        {
            using (var context = new QuoteCreatorContext())
            {
                return context.Quotes.Include("Customer").Include("QuoteProducts").ToList();
            }
        }
        public void AddQuote(Quote newQuote)
        {
            using (var context = new QuoteCreatorContext())
            {
                context.Quotes.Add(newQuote);
                context.SaveChanges();
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            using (var context = new QuoteCreatorContext())
            {
                return context.Customers.ToList();
            }
        }
        public Customer GetCustomerById(int id)
        {
            using (var context = new QuoteCreatorContext())
            {
                return context.Customers.First(c => c.Id == id);
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using (var context = new QuoteCreatorContext())
            {
                return context.Products.ToList();
            }
        }
        public Quote GetQuoteById(int? id)
        {
            using (var context = new QuoteCreatorContext())
            {
                return context.Quotes.Include("Customer").Include("QuoteProducts").Include("QuoteProducts.Product").First(q => q.Id == id);
            }
        }
    }
}