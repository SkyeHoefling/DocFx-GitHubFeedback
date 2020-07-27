namespace GitHubFeedback.Core
{
    public interface IGitHubSettings
    {
        string AccessToken { get; }
        string UserAgent { get; }
    }
}
