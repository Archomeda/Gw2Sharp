using System;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi;
using Newtonsoft.Json.Serialization;

namespace Gw2Sharp.Json
{
    internal class Gw2ContractResolver : DefaultContractResolver
    {
        private readonly RenderUrlConverter renderUrlConverter;

        public Gw2ContractResolver(IGw2Client client)
        {
            this.renderUrlConverter = new RenderUrlConverter(client);
        }

        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);

            // Custom converters
            if (objectType == typeof(RenderUrl))
                contract.Converter = this.renderUrlConverter;
            else if (objectType == typeof(RenderUrl?))
                contract.Converter = this.renderUrlConverter;

            return contract;
        }
    }
}
