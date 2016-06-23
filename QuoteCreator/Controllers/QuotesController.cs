using QuoteCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuoteCreator.Controllers
{
    public class QuotesController : Controller
    {
        private readonly QuoteRepository quoteRepository;
        public QuotesController()
        {
            //DI
            this.quoteRepository = new QuoteRepository();
        }

        public ActionResult Index()
        {
            return View(this.quoteRepository.GetAll().Select(QuoteDto.FromQuote));
        }

        public ActionResult Create()
        {
            ViewBag.Customers = this.quoteRepository.GetAllCustomers();
            ViewBag.Products = this.quoteRepository.GetAllProducts();
            return View(new QuoteDto());
            //var a = this.quoteRepository.GetQuoteById(2);
            //return View(QuoteDto.FromQuote(a));
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = quoteRepository.GetQuoteById(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

    }
}