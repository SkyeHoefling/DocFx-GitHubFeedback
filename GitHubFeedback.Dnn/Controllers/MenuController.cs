using DotNetNuke.Entities.Portals;
using DotNetNuke.Web.Api;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GitHubFeedback.Dnn.Controllers
{
    public class MenuController : DnnApiController
    {
        // This is a carbon-copy of the pass-phrase from `DnnGitHubSettings`
        const string Setting_PassPhrase = "{0}kdZH*p6rE6h$ZMmdEQAG9gDr8CeUC";

        // This a Secured API to update encrypted settings until a UI is built
        [HttpGet]
        public HttpResponseMessage Update(string name, string value)
        {
            var passPhrase = string.Format(Setting_PassPhrase, PortalSettings.PortalId);
            PortalController.UpdateEncryptedString(PortalSettings.PortalId, name, value, passPhrase);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
