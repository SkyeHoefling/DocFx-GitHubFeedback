namespace GitHubFeedback.Core
{
    public interface IGitHubSettings
    {
        string AccessToken { get; }
        string UserAgent { get; }
        string Organization { get; }
        string Repository { get; }
    }
}
