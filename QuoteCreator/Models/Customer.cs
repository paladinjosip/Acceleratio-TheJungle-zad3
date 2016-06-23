﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuoteCreator.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OIB { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
    }
}