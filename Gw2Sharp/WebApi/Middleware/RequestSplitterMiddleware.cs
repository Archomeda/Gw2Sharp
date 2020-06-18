using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Http;

namespace Gw2Sharp.WebApi.Middleware
{
    /// <summary>
    /// The request splitter middleware.
    /// </summary>
    public class RequestSplitterMiddleware : IWebApiMiddleware
    {
        private int maxRequestSize = 200;

        /// <summary>
        /// The maximum allowed request size.
        /// Defaults to 200.
        /// </summary>
        public int MaxRequestSize
        {
            get => this.maxRequestSize;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException(nameof(value), "The maximum request size needs to be at least 1");
                this.maxRequestSize = value;
            }
        }

        /// <inheritdoc />
        public virtual Task<IWebApiResponse> OnRequestAsync(IConnection connection, IWebApiRequest request, Func<IWebApiRequest, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken = default)
        {
            if (connection is null)
                throw new ArgumentNullException(nameof(connection));
            if (request is null)
                throw new ArgumentNullException(nameof(request));
            if (callNext is null)
                throw new ArgumentNullException(nameof(callNext));
            return ExecAsync();

            async Task<IWebApiResponse> ExecAsync()
            {
                string[] idsList = Array.Empty<string>();
                if (request.Options.EndpointQuery.TryGetValue(request.Options.BulkQueryParameterIdsName, out string? ids))
                    idsList = ids.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (idsList.Length <= this.MaxRequestSize)
                    return await callNext(request, cancellationToken).ConfigureAwait(false);

                var partitions = Partitioner.Create(0, idsList.Length, this.MaxRequestSize).GetDynamicPartitions();
                var partitionRequests = partitions.Select(x =>
                {
                    string[] partitionIds = idsList[x.Item1..x.Item2];
                    var partitionRequest = request.DeepCopy();
                    partitionRequest.Options.EndpointQuery[request.Options.BulkQueryParameterIdsName] = string.Join(",", partitionIds);
                    return partitionRequest;
                });

                var partitionResponses = new List<IWebApiResponse>();
                foreach (var partitionRequest in partitionRequests)
                    partitionResponses.Add(await callNext(partitionRequest, cancellationToken).ConfigureAwait(false));
                return partitionResponses.Merge();
            }
        }
    }
}
