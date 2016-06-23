using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuoteCreator.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public Customer Customer { get; set; }
        public ICollection<QuoteProduct> QuoteProducts { get; set; }
    }
}