using Microsoft.Owin;
using Ninject;
using Owin;
using System.Reflection;

[assembly: OwinStartupAttribute(typeof(ForumSystem.Startup))]
namespace ForumSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }

    private static StandardKernel CreateKernel()
    {
        var kernel = new StandardKernel();
        kernel.Load(Assembly.GetExecutingAssembly());
        return kernel;
    }
}
