using DotNetNuke.DependencyInjection;
using GitHubFeedback.Core;
using Microsoft.Extensions.DependencyInjection;

namespace GitHubFeedback.Dnn
{
    public class Startup : IDnnStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGitHubSettings, DnnGitHubSettings>();
        }
    }
}
