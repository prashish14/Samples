using System;
using System.Web.Http;
using Autofac;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Autofac.Integration.WebApi;
using Owin;
using System.Reflection;
using System.Globalization;
using System.Configuration;

[assembly: OwinStartup(typeof(Sample.Application.WebApi.Startup))]

namespace Sample.Application.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<WebApiModule>();
            var config = new HttpConfiguration();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired();

            var container = builder.Build();
            var sampleDependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            var culture = new CultureInfo("en-US") { DateTimeFormat = { ShortDatePattern = "MM/dd/yyyy", LongTimePattern = "" } };
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            var formatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter();
            config.Formatters.Add(formatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            var clientFolder = ConfigurationManager.AppSettings["ClientFolder"];

            app.MapWhen(context =>
            {
                return true;
            },
            trueApp =>
            {
                var fileServerOptions = new FileServerOptions()
                {
                    RequestPath = PathString.Empty,
                    FileSystem = new PhysicalFileSystem(@".\" + clientFolder),
                };
                trueApp.UseFileServer(fileServerOptions);
                trueApp.UseWebApi(config);
            });
        }
    }
}
