using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// An interface for implementing a generic JSON web API response.
    /// </summary>
    public interface IWebApiResponse : IWebApiResponse<string>
    {
        /// <summary>
        /// Creates a copy of the request.
        /// This deep copies <see cref="IWebApiResponse{T}.ResponseHeaders" />.
        /// </summary>
        /// <returns>The cloned response.</returns>
        new IWebApiResponse Copy();
    }

    /// <summary>
    /// An interface for implementing a deserialized web API response.
    /// </summary>
    /// <typeparam name="T">The response object type.</typeparam>
    public interface IWebApiResponse<out T>
    {
        /// <summary>
        /// The content.
        /// </summary>
        T Content { get; }

        /// <summary>
        /// The status code.
        /// </summary>
        HttpStatusCode StatusCode { get; }

        /// <summary>
        /// The response headers.
        /// </summary>
        IDictionary<string, string> ResponseHeaders { get; }

        /// <summary>
        /// Creates a copy of the request.
        /// This deep copies <see cref="IWebApiResponse{T}.ResponseHeaders" />, but copies <see cref="Content" /> by reference.
        /// </summary>
        /// <returns>The cloned response.</returns>
        IWebApiResponse<T> Copy();
    }


    internal static class IWebApiResponseExtensions
    {
        public static IWebApiResponse Merge(this IEnumerable<IWebApiResponse> responses)
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            writer.WriteStartArray();
            foreach (var response in responses)
            {
                using var doc = JsonDocument.Parse(response.Content);
                switch (doc.RootElement.ValueKind)
                {
                    case JsonValueKind.Array:
                        foreach (var element in doc.RootElement.EnumerateArray())
                            element.WriteTo(writer);
                        break;
                    default:
                        doc.RootElement.WriteTo(writer);
                        break;
                }
            }
            writer.WriteEndArray();
            writer.Flush();

            stream.Position = 0;
            var firstResponse = responses.FirstOrDefault();
            using var reader = new StreamReader(stream);
            return new WebApiResponse(reader.ReadToEnd(), firstResponse?.StatusCode, firstResponse?.ResponseHeaders);
        }
    }
}
