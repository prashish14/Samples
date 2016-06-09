using System;
using System.Web.Mvc;
using Ebuy.Website.Models;

namespace Ebuy.Website.Controllers
{
    public class AuctionsController : Controller
    {
        // GET: /Details/
        public ActionResult Details()
        {
            var auction = new Auction()
            {
                Title = "Brand new Widge 2.0",
                Description = "This is brand new verison 2.0 Widget!",
                StartPrice = 1.00m,
                CurrentPrice = 13.40m,
                EndTime = DateTime.Now
            };

            return View(auction);
        }

        // GET: /Create/
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Create/
        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            return View(auction);
        }
    }
}
