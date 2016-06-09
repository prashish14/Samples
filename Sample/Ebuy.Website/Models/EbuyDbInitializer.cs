
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Ebuy.Website.Models
{
    public class EbuyDbInitializer : DropCreateDatabaseAlways<EbuyDataContext> // DropCreateDatabaseAlways<EbuyDataContext> //: DropCreateDatabaseIfModelChanges<EbuyDataContext>
    {
        protected override void Seed(EbuyDataContext context)
        {
            List<Auction> auctions = new List<Auction>()
            {
                new Auction()
                {
                    Title = "Watch",
                    Description = "Apple watch",
                    StartPrice = 500,
                    CurrentPrice = 1000,
                    EndTime = DateTime.Now
                }
            };

            foreach (var auction in auctions)
            {
                context.Auctions.Add(auction);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}