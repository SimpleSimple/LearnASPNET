using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NHibernate_AspNetMvc.Startup))]
namespace NHibernate_AspNetMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
