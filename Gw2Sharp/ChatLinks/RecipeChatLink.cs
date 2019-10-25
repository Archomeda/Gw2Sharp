using Gw2Sharp.ChatLinks.Structs;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 recipe chat link.
    /// </summary>
    public class RecipeChatLink : Gw2ChatLink<RecipeChatLinkStruct>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Recipe;

        /// <summary>
        /// The recipe id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Recipes"/>.
        /// </summary>
        public int RecipeId
        {
            get => this.data.RecipeId;
            set => this.data.RecipeId = (ushort)value;
        }
    }
}
