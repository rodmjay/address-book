using System.Web.Http;
using System.Web.Http.Cors;
using AddressBook;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace AddressBook
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            var cors = new EnableCorsAttribute(origins: "*", headers: "*", methods: "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();
            config.Formatters.Clear();
            config.Formatters.Add(new BrowserJsonFormatter());
            app.UseWebApi(config);
        }
    }
}