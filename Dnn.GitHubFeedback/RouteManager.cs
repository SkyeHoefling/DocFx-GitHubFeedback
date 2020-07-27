using DotNetNuke.Web.Api;

namespace Dnn.GitHubFeedback
{
    public class RouteManager : IServiceRouteMapper
    {
        // API Route - ~/api/Dnn.GitHubFeedback/{controller}/{action}
        // ex: ~/api/Dnn.GitHubFeedback/Home/Ping
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("Dnn.GitHubFeedback", "default", "{controller}/{action}", new[] { "Dnn.GitHubFeedback.Controllers" });
        }
    }
}
