using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DvdLibrary.Startup))]
namespace DvdLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
