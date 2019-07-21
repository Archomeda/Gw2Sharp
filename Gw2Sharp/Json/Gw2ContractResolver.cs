using System;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;

namespace Gw2Sharp.Json
{
    internal class Gw2ContractResolver : DefaultContractResolver
    {
        private readonly IGw2Client client;

        public Gw2ContractResolver(IGw2Client client)
        {
            this.client = client;
        }

        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
            contract.OnDeserializingCallbacks.Add(this.OnDeserializing);
            return contract;
        }

        private void OnDeserializing(object obj, StreamingContext streamingContext)
        {

        }
    }
}
