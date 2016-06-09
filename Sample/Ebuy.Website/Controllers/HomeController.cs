using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ebuy.Website.Models;

namespace Ebuy.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            var company = new CompanyInfo
            {
                Name = "EBuy: The ASP.NET MVC Demo Site",
                Description = "EBuy is the world leader in ASP.NET MVC demoing!"
            };

            return View("About", company); // company will be set to ViewData.Model
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create(Auction auction)
        {
            //one way (bad practice)
            //var auction = new Auction()
            //{
            //    Id = int.Parse(Request["id"]),
            //    Title = Request["title"],
            //    StartPrice = Decimal.Parse(Request["startPrice"]),
            //    CurrentPrice = Decimal.Parse(Request["currentPrice"]),
            //    StartTime = DateTime.Parse(Request["title"]),
            //    EndTime = DateTime.Parse(Request["title"])
            //};

            return View(auction);
        }

        public void Auction(int id)
        {
            //var context = new EBuyContext();
            //var auction = context.Auctions.FirstOrDefault(x => x.Id == id);
        }
    }
}
