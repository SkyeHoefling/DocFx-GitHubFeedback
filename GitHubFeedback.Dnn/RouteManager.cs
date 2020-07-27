using DotNetNuke.Web.Api;

namespace GitHubFeedback.Dnn
{
    public class RouteManager : IServiceRouteMapper
    {
        // API Route - ~/api/GitHubFeedback.Dnn/{controller}/{action}
        // ex: ~/api/Dnn.GitHubFeedback/Home/Ping
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("GitHubFeedback.Dnn", "default", "{controller}/{action}", new[] { "GitHubFeedback.Dnn.Controllers" });
        }
    }
}
