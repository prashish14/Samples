using System;
using System.Data.Entity.Migrations.Infrastructure;
using System.IO;

namespace Sample.Application.Database.Databases.Mvc4
{
    internal sealed partial class Version1 : IMigrationMetadata
    {
        string IMigrationMetadata.Id
        {
            get
            {
                return "000000000000001_version";
            }
        }

        string IMigrationMetadata.Source
        {
            get { return null; }
        }

        string IMigrationMetadata.Target
        {
            get
            {
                return System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Databases\\Mvc4\\Version1\\Mvc4_Version1_ModelBase64.txt"));
            }
        }
    }
}
