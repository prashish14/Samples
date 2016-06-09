using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Application.DAL.Entities.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DeliveredTime { get; set; }
    }
}