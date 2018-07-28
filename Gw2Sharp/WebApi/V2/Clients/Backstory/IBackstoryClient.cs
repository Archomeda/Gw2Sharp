namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 backstory endpoint.
    /// </summary>
    public interface IBackstoryClient : IClient
    { 
        /// <summary>
        /// Gets the backstory answers.
        /// </summary>
        IBackstoryAnswersClient Answers { get; }

        /// <summary>
        /// Gets the backstory questions.
        /// </summary>
        IBackstoryQuestionsClient Questions { get; }
    }
}
