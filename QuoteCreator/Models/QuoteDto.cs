using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuoteCreator.Models
{
    public class QuoteDto
    {
        public QuoteDto()
        {
            QuoteProducts = new List<QuoteProduct>();
        }

        public static QuoteDto FromQuote(Quote quote)
        {
            return new QuoteDto()
            {
                Id = quote.Id,
                Total = quote.Total,
                Customer = quote.Customer,
                CustomerId = quote.Customer.Id,
                QuoteProducts = quote.QuoteProducts
            };
        }
        public int Id { get; set; }

        public decimal Total { get; set; }
        public int CustomerId { get; set; }
        public int NewProductId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<QuoteProduct> QuoteProducts { get; set; }
    }
}