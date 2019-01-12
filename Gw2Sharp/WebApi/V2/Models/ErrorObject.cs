using Newtonsoft.Json;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a generic error object.
    /// </summary>
    /// <remarks>
    /// Because of how the API works, either <see cref="Text"/> or <see cref="Error"/> is set.
    /// You can use <see cref="Message"/> to prioritize <see cref="Text"/> above <see cref="Error"/>.
    /// </remarks>
    public class ErrorObject
    {
        /// <summary>
        /// The error message.
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// The error message.
        /// </summary>
        public string? Error { get; set; }

        /// <summary>
        /// The generalized error message.
        /// </summary>
        [JsonIgnore]
        public string Message => this.Text ?? this.Error ?? string.Empty;
    }
}
