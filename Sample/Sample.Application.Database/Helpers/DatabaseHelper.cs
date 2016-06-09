using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Application.Database.Configuration;
using Sample.Application.DAL.Contexts;

namespace Sample.Application.Database.Helpers
{
    public static class DatabaseHelper
    {
        public static void SynchronizeModelBase64(DbContext context, int version, string contextFolder)
        {
            var modelBase64 = ModelHelper.GenerateModel(context);

            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, string.Format("{0}_Version{1}_ModelBase64.txt", contextFolder, version)), modelBase64);
        }

        public static void CreatedDatabase(DbContext context, int lastVersion, bool? isAddTestData = null)
        {
            Console.WriteLine("Database " + context.Database.Connection.Database);

            if (!context.Database.Exists())
            {
                throw new ApplicationException("Database is not found");
                CreateDatabase(context, lastVersion);
            }
            else
            {
                using (SqlConnection cnn = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    cnn.Open();
                    SqlCommand cmm = new SqlCommand(String.Format("use master ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE {0};", context.Database.Connection.Database), cnn);
                    cmm.ExecuteNonQuery();
                }
                Console.WriteLine("Current database is deleted.");
                CreateDatabase(context, lastVersion);
            }
        }

        private static void CreateDatabase(DbContext context, int lastVersion)
        {
            for (int i = 1; i <= lastVersion; i++)
            {
                var dbMigrator = CreateDbMigrator(context);
                var versionName = GetVersionName(i);
                dbMigrator.Update(versionName);
                Console.WriteLine("Version [" + versionName + "] has been created");
            }
        }

        private static DbMigrator CreateDbMigrator(DbContext context)
        {
            DbMigrationsConfiguration dbMigrationsConfiguration = null;
            if (context is SampleDbContext)
            {
                dbMigrationsConfiguration = new Sample.Application.Database.Databases.Mvc4.Configuration();
                dbMigrationsConfiguration.CommandTimeout = 7200;
            }    

            return new DbMigrator(dbMigrationsConfiguration);
        }

        private static string GetVersionName(int version)
        {
            const int versionMaxLength = 14;
            var countDigits = version.ToString().Length;
            var versionName = new StringBuilder();
            for (var i = 0; i <= versionMaxLength - countDigits; i++)
            {
                versionName.Append("0");
            }
            return versionName.ToString() + version + "_version";
        }
    }
}
