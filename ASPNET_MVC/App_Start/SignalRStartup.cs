using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ASPNET_MVC.App_Start.SignalRStartup))]

namespace ASPNET_MVC.App_Start
{
    public class SignalRStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            // Uygulamanızı nasıl yapılandıracağınız hakkında daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=316888 adresini ziyaret edin
        }
    }
}
