using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Application.Mvc4.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public double CurrentPrice { get; set; }

        public string Url { get; set; }
        public string ImageUrl { get; set; }
    }
}