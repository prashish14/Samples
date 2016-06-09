using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Sample.Application.Database.Configuration
{
    public static class ConfigurationManager
    {
        public static Dictionary<string, int> DatabaseContexts
        {
            get
            {
                var dbContexts = new Dictionary<string, int>();

                foreach (var context in System.Configuration.ConfigurationManager.AppSettings["DbContext"])
                {
                    string dbContext = context.ToString();
                    if (String.IsNullOrEmpty(dbContext))
                    {
                        throw new ConfigurationErrorsException("DbContext isn't set.");
                    }
                    string[] nameVersionPair = dbContext.Split('-');
                    string contextName = nameVersionPair.First();
                    int contextVersion = int.Parse(nameVersionPair.Last());

                    dbContexts.Add(contextName, contextVersion);
                }

                return dbContexts;
            }
        }
    }
}
