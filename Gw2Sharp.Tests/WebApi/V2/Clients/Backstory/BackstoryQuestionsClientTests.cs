using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class BackstoryQuestionsClientTests : BaseEndpointClientTests<IBackstoryQuestionsClient>
    {
        protected override IBackstoryQuestionsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Backstory.Questions;

        [Theory]
        [InlineData("TestFiles.Backstory.BackstoryQuestions.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Backstory.BackstoryQuestions.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Backstory.BackstoryQuestions.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Backstory.BackstoryQuestions.bulk.json")]
        public Task AllTestAsync(string file) => this.AssertAllDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Backstory.BackstoryQuestions.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsDataAsync(this.Client, file);
    }
}
