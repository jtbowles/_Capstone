using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DogBreederCapstone.Startup))]
namespace DogBreederCapstone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
