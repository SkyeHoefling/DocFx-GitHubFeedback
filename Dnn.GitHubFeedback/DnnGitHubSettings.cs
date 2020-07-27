using DotNetNuke.Entities.Portals;
using GitHubFeedback.Core;

namespace Dnn.GitHubFeedback
{
    internal class DnnGitHubSettings : IGitHubSettings
    {
        const string Setting_UserAgent = "GitHubFeedback.UserAgent";
        const string Setting_AccessToken = "GitHubFeedback.AccessToken";
        const string Setting_PassPhrase = "{0}kdZH*p6rE6h$ZMmdEQAG9gDr8CeUC";

        public DnnGitHubSettings()
        {
            var passPhrase = string.Format(Setting_PassPhrase, 0);

            AccessToken = PortalController.GetEncryptedString(Setting_AccessToken, 0, passPhrase);
            if (string.IsNullOrEmpty(AccessToken))
            {
                var accessToken = "5216084aa40eb2063b414f8e2c8ccf19f42cfc19";
                PortalController.UpdateEncryptedString(0, Setting_AccessToken, accessToken, passPhrase);
                AccessToken = accessToken;
            }

            //https://docs.github.com/en/rest/overview/resources-in-the-rest-api#user-agent-required
            UserAgent = PortalController.GetEncryptedString(Setting_UserAgent, 0, passPhrase);
            if (string.IsNullOrEmpty(UserAgent))
            {
                var userAgent = "ahoefling";
                PortalController.UpdateEncryptedString(0, Setting_UserAgent, userAgent, passPhrase);
                UserAgent = userAgent;
            }
        }
        public string AccessToken { get; private set; }

        public string UserAgent { get; private set; }
    }
}
