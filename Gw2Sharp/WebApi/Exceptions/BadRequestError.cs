namespace Gw2Sharp.WebApi.Exceptions
{
    /// <summary>
    /// Bad request errors.
    /// </summary>
    public enum BadRequestError
    {
        /// <summary>
        /// Generic bad request.
        /// </summary>
        GenericBadRequest,

        /// <summary>
        /// The provided list of ids is too long.
        /// </summary>
        ListTooLong,

        /// <summary>
        /// The provided page is out of range.
        /// </summary>
        PageOutOfRange
    }
}
