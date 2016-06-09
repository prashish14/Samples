using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Application.Database.Configuration;
using Sample.Application.Database.Helpers;
using Sample.Application.DAL.Contexts;

namespace Sample.Application.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                foreach (var dbContext in ConfigurationManager.DatabaseContexts)
                {
                    DbContext dataContext;
                    string contextFolder = String.Empty;

                    switch (dbContext.Key)
                    {
                        case "SampleDbContext":
                            {
                                dataContext = new SampleDbContext();
                                contextFolder = "Sample";
                                break;
                            }
                        default: 
                            throw new NotSupportedException(String.Format("Unknow database context: {0}.", dbContext.Key));
                    }

                    DatabaseHelper.SynchronizeModelBase64(dataContext, dbContext.Value, contextFolder);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Message: {0}", ex.Message);
                Console.WriteLine("InnerException: {0}", ex.InnerException);
                Console.ReadLine();
            }
        }
    }
}
