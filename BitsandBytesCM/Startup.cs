using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BitsandBytesCM.Startup))]
namespace BitsandBytesCM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
