using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sample.Application.Mvc4.Models;

namespace Sample.Application.Mvc4.Controllers
{
    public class AuctionController : Controller
    {
        // GET: /Auction/
        [HttpGet]
        public ActionResult Auction()
        {
            Auction auction = new Auction()
            {
                Id = 1,
                Title = "Test Auction",
                Url = "http://vk.com",
                ImageUrl = "http://mail.ru"
            };
            return View(auction);
        }
    }
}
