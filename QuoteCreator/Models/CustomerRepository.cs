using QuoteCreator.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuoteCreator.Models
{
    public class CustomerRepository
    {
        public IEnumerable<Customer> GetAll()
        {
            using (var context = new QuoteCreatorContext())
            {
                return context.Customers.ToList();
            }
        }

        public void AddCustomer(Customer newCustomer)
        {
            using (var context = new QuoteCreatorContext())
            {
                context.Customers.Add(newCustomer);
                context.SaveChanges();
            }
        }
        public void FindCustomerById(int id)
        {
            using (var context = new QuoteCreatorContext())
            {
                context.Customers.First(c => c.Id == id);
            }
        }
    }
}