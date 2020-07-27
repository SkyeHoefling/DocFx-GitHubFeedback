using DotNetNuke.Web.Api;
using GitHubFeedback.Core;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace GitHubFeedback.Dnn.Controllers
{
    public class IssuesController : DnnApiController
    {
        const string RepositoryIssues = "/repos/{0}/{1}/issues";
        const string BaseAddress = "https://api.github.com";

        protected IGitHubSettings Settings { get; }
        public IssuesController(IGitHubSettings settings)
        {
            Settings = settings;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> List(int page, int pageSize)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);
                var request = new HttpRequestMessage(HttpMethod.Get, string.Format(RepositoryIssues, Settings.Organization, Settings.Repository));
                AddHeaders(request);

                return await client.SendAsync(request);
            }
        }

        void AddHeaders(HttpRequestMessage request)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("token", Settings.AccessToken);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            request.Headers.Add("User-Agent", Settings.UserAgent);
        }
    }
}
