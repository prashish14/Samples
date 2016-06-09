using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Application.DAL.Entities.Interfaces;

namespace Sample.Application.DAL
{
    public class DALModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
        }
    }
}
