using System.Data.Entity;

namespace Ebuy.Website.Models
{
    public class EbuyDataContext : DbContext
    {
        public EbuyDataContext()
            :base("DefaultConnection")
        {
            Database.SetInitializer(new EbuyDbInitializer());
        }

        public DbSet<Auction> Auctions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}