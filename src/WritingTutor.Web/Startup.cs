using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WritingTutor.Web.Startup))]
namespace WritingTutor.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
