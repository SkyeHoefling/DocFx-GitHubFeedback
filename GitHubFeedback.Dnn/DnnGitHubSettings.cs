using DotNetNuke.Entities.Portals;
using GitHubFeedback.Core;

namespace GitHubFeedback.Dnn
{
    internal class DnnGitHubSettings : IGitHubSettings
    {
        const string Setting_UserAgent = "GitHubFeedback.UserAgent";
        const string Setting_AccessToken = "GitHubFeedback.AccessToken";
        const string Setting_Organization = "GitHubFeedback.Organization";
        const string Setting_Repository = "GitHubFeedback.Repository";
        const string Setting_PassPhrase = "{0}kdZH*p6rE6h$ZMmdEQAG9gDr8CeUC";

        public DnnGitHubSettings()
        {
            var passPhrase = string.Format(Setting_PassPhrase, 0);

            AccessToken = PortalController.GetEncryptedString(Setting_AccessToken, 0, passPhrase);
            UserAgent = PortalController.GetEncryptedString(Setting_UserAgent, 0, passPhrase); //https://docs.github.com/en/rest/overview/resources-in-the-rest-api#user-agent-required
            Organization = PortalController.GetEncryptedString(Setting_Organization, 0, passPhrase);
            Repository = PortalController.GetEncryptedString(Setting_Repository, 0, passPhrase);
        }

        public string AccessToken { get; private set; }

        public string UserAgent { get; private set; }

        public string Organization { get; private set; }

        public string Repository { get; private set; }
    }
}
