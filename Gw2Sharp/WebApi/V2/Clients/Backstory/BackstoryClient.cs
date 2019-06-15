using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 backstory endpoint.
    /// </summary>
    [EndpointPath("backstory")]
    public class BackstoryClient : BaseClient, IBackstoryClient
    {
        private readonly IBackstoryAnswersClient answers;
        private readonly IBackstoryQuestionsClient questions;

        /// <summary>
        /// Creates a new <see cref="BackstoryClient"/> that is used for the API v2 backstory endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public BackstoryClient(IConnection connection) :
            base(connection)
        {
            this.answers = new BackstoryAnswersClient(connection);
            this.questions = new BackstoryQuestionsClient(connection);
        }

        /// <inheritdoc />
        public virtual IBackstoryAnswersClient Answers => this.answers;

        /// <inheritdoc />
        public virtual IBackstoryQuestionsClient Questions => this.questions;
    }
}
