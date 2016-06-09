using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Application.DAL.Contexts;
using Sample.Application.DAL.Entities.Entities;
using Sample.Application.DAL.Entities.Interfaces;

namespace Sample.Application.DAL.Repositories
{
    public class BlogRepository
    {
        private IDbFactory _dbFactory { get; set; }
        private DbSet<Blog> _dbSet { get; set; }

        public BlogRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _dbSet = ((DbContext)_dbFactory.Get<SampleDbContext>()).Set<Blog>();
        }

        public Blog GetById(int id)
        {
            var blog = _dbSet.Find(id);
            return blog;
        }
    }
}
