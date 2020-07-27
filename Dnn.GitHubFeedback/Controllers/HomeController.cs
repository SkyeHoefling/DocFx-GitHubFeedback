using DotNetNuke.Web.Api;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Dnn.GitHubFeedback.Controllers
{
    public class HomeController : DnnApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Ping()
        {
            var jsonContent = new StringContent("pong", Encoding.UTF8, "application/json");
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = jsonContent };
        }
    }
}
