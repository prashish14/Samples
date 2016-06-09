using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Database.Databases.Mvc4
{
    internal sealed class Configuration : DbMigrationsConfiguration<Sample.Application.DAL.Contexts.SampleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Sample.Application.DAL.Contexts.SampleDbContext context)
        {

        }
    }
}
