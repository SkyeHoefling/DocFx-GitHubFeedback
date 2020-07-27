using DotNetNuke.Web.Api;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace Dnn.GitHubFeedback.Controllers
{
    public class IssuesController : DnnApiController
    {
        const string RepositoryIssues = "/repos/{0}/{1}/issues";
        const string BaseAddress = "https://api.github.com";
        const string AuthorizationToken = "***";

        [HttpGet]
        public async Task<HttpResponseMessage> List(int page, int pageSize)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);
                var request = new HttpRequestMessage(HttpMethod.Get, string.Format(RepositoryIssues, "FileOnQ", "Wiki"));
                request.Headers.Authorization = new AuthenticationHeaderValue("token", AuthorizationToken);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

                request.Headers.Add("User-Agent", "ahoefling"); //https://docs.github.com/en/rest/overview/resources-in-the-rest-api#user-agent-required

                return await client.SendAsync(request);
            }
        }
    }
}
