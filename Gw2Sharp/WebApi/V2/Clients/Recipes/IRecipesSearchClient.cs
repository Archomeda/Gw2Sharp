using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 recipes search endpoint.
    /// </summary>
    public interface IRecipesSearchClient :
        IBlobClient<IApiV2ObjectList<int>>
    {
        /// <summary>
        /// The parameter for requesting a recipe with a specific input item id.
        /// Exactly one of <see cref="ParamInput"/> or <see cref="ParamOutput"/> can be used.
        /// If none is given, an <see cref="InvalidOperationException"/> will be thrown when requesting.
        /// </summary>
        int? ParamInput { get; }

        /// <summary>
        /// The parameter for requesting a recipe with a specific output item id.
        /// Exactly one of <see cref="ParamInput"/> or <see cref="ParamOutput"/> can be used.
        /// If none is given, an <see cref="InvalidOperationException"/> will be thrown when requesting.
        /// </summary>
        int? ParamOutput { get; }

        /// <summary>
        /// Sets the parameter for requesting a recipe with a specific input item id.
        /// Setting this will override <see cref="ParamOutput"/> to <c>null</c>,
        /// because only one of <see cref="ParamInput"/> or <see cref="ParamOutput"/> can be used at the same time.
        /// </summary>
        /// <param name="inputItemId">The input item id.</param>
        /// <returns><c>this</c> to allow method chaining.</returns>
        IRecipesSearchClient Input(int inputItemId);

        /// <summary>
        /// Sets the parameter for requesting a recipe with a specific output item id.
        /// Setting this will override <see cref="ParamInput"/> to <c>null</c>,
        /// because only one of <see cref="ParamInput"/> or <see cref="ParamOutput"/> can be used at the same time.
        /// </summary>
        /// <param name="outputItemId">The input item id.</param>
        /// <returns><c>this</c> to allow method chaining.</returns>
        IRecipesSearchClient Output(int outputItemId);
    }
}
