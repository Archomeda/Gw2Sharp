using System;
using System.Runtime.Serialization;
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
    [JsonObject]
    [Serializable]
    public class ErrorObject : ApiV2BaseObject, ISerializable
    {
        /// <summary>
        /// Creates a new <see cref="ErrorObject"/>.
        /// </summary>
        public ErrorObject() { }

        /// <summary>
        /// Deserialization constructor for <see cref="ErrorObject"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected ErrorObject(SerializationInfo info, StreamingContext context)
        {
            this.Text = info.GetString(nameof(this.Text));
            this.Error = info.GetString(nameof(this.Error));
        }

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

        /// <inheritdoc />
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue(nameof(this.Text), this.Text, typeof(string));
            info.AddValue(nameof(this.Error), this.Error, typeof(string));
        }
    }
}
