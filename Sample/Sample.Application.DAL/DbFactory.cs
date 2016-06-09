using System;
using System.Collections.Generic;
using System.Data.Entity;
using Sample.Application.DAL.Contexts;
using Sample.Application.DAL.Entities.Interfaces;

namespace Sample.Application.DAL
{
    public class DbFactory : Disposable, IDbFactory
    {
        private Dictionary<Type, DbContext> _dataContexts = new Dictionary<Type, DbContext>();

        private EventHandler<EventArgs> dbContextUpdated;
        public event EventHandler<EventArgs> DbContextUpdated
        {
            add
            {
                dbContextUpdated += value;
            }
            remove
            {
                dbContextUpdated -= value;
            }
        }

        public void UpdateDbContext<TContext>(string dbName, string serverName, bool isCommit) where TContext : DbContext
        {
            var contextType = typeof(TContext);

            RemoveContext(contextType, isCommit);
            AddContext(contextType);
            OnDbContextUpdated();
        }

        private void OnDbContextUpdated()
        {
            EventHandler<EventArgs> handlers = dbContextUpdated;
            if (handlers != null)
                handlers(this, new EventArgs());
        }

        public IDatabaseContext Get<TContext>() where TContext : DbContext
        {
            if (!_dataContexts.ContainsKey(typeof(TContext)))
            {
                AddContext(typeof(TContext));
            }
            return (IDatabaseContext)_dataContexts[typeof(TContext)];
        }

        public IDatabaseContext GetDefault()
        {
            return Get<SampleDbContext>();
        }

        protected override void DisposeCore()
        {
            if (_dataContexts != null)
            {
                foreach (var dataContext in _dataContexts)
                    dataContext.Value.Dispose();
                _dataContexts = null;
            }
        }

        private void AddContext(Type contextType)
        {
            DbContext dataContext;
            if (contextType == typeof(SampleDbContext))
            {
                dataContext = new SampleDbContext();
            }
            else
            {
                throw new NotSupportedException(contextType.ToString());
            }
            _dataContexts.Add(contextType, dataContext);
        }

        private void RemoveContext(Type contextType, bool isCommit)
        {
            if (_dataContexts.ContainsKey(contextType))
            {
                if (isCommit)
                {
                    _dataContexts[contextType].SaveChanges();
                }
                _dataContexts[contextType].Dispose();
                _dataContexts.Remove(contextType);
            }
        }
    }

    public class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }
    }
}
