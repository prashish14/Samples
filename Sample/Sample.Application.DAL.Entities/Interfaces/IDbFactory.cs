using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.DAL.Entities.Interfaces
{
    public interface IDbFactory
    {
        IDatabaseContext Get<TContext>() where TContext : DbContext;
        IDatabaseContext GetDefault();
        void UpdateDbContext<TContext>(string dbName, string serverName, bool isCommit) where TContext : DbContext;
        event EventHandler<EventArgs> DbContextUpdated;
    }
}
