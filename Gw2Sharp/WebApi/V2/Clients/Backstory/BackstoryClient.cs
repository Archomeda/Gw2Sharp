using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 backstory endpoint.
    /// </summary>
    [EndpointPath("backstory")]
    public class BackstoryClient : Gw2WebApiBaseClient, IBackstoryClient
    {
        private readonly IBackstoryAnswersClient answers;
        private readonly IBackstoryQuestionsClient questions;

        /// <summary>
        /// Creates a new <see cref="BackstoryClient"/> that is used for the API v2 backstory endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal BackstoryClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.answers = new BackstoryAnswersClient(connection, gw2Client);
            this.questions = new BackstoryQuestionsClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IBackstoryAnswersClient Answers => this.answers;

        /// <inheritdoc />
        public virtual IBackstoryQuestionsClient Questions => this.questions;
    }
}
