using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2;
using Gw2Sharp.WebApi.V2.Clients;
using Gw2Sharp.WebApi.V2.Models;
using Newtonsoft.Json.Linq;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public abstract class BaseEndpointClientTests
    {
        public IEndpointClient Client { get; protected set; } = default!;

        [Fact]
        public void InterfaceConsistencyTest()
        {
            Assert.Equal(this.CheckIfImplementsInterface(this.Client, typeof(IPaginatedClient<>)), this.Client.IsPaginated);
            Assert.Equal(this.CheckIfImplementsInterface(this.Client, typeof(IAuthenticatedClient<>)), this.Client.IsAuthenticated);
            Assert.Equal(this.CheckIfImplementsInterface(this.Client, typeof(ILocalizedClient<>)), this.Client.IsLocalized);
            Assert.Equal(this.CheckIfImplementsInterface(this.Client, typeof(IBlobClient<>)), this.Client.HasBlobData);
            Assert.Equal(this.CheckIfImplementsInterface(this.Client, typeof(IAllExpandableClient<>)), this.Client.IsAllExpandable);
            Assert.Equal(this.CheckIfImplementsInterface(this.Client, typeof(IBulkExpandableClient<,>)), this.Client.IsBulkExpandable);
        }

        private bool CheckIfImplementsInterface(IClient client, Type interfaceType) =>
            client.GetType().GetInterfaces()
                .Where(i => i.IsGenericType)
                .Any(i => i.GetGenericTypeDefinition() == interfaceType);


        #region Request Assertions

        protected virtual async Task AssertPaginatedDataAsync<TObject>(IPaginatedClient<TObject> client, string file)
            where TObject : IApiV2Object
        {
            var (data, expected) = this.GetTestData(file);

            ((IWebApiClientInternal)this.Client).Connection.HttpClient.RequestAsync(Arg.Any<IHttpRequest>(), CancellationToken.None).Returns(callInfo =>
            {
                this.AssertRequest(callInfo, client, "?page=2&page_size=100");
                this.AssertAuthenticatedRequest(callInfo, client);
                this.AssertLocalizedRequest(callInfo, client);
                this.AssertSchemaVersionRequest(callInfo, client);
                return new HttpResponse(data, HttpStatusCode.OK, null, null);
            });

            var actual = await client.PageAsync(2, 100);
            this.AssertJsonObject(expected, actual);
        }

        protected virtual async Task AssertBlobDataAsync<TObject>(IBlobClient<TObject> client, string file)
            where TObject : IApiV2Object
        {
            var (data, expected) = this.GetTestData(file);
            ((IWebApiClientInternal)this.Client).Connection.HttpClient.RequestAsync(Arg.Any<IHttpRequest>(), CancellationToken.None).Returns(callInfo =>
            {
                this.AssertRequest(callInfo, client, string.Empty);
                this.AssertAuthenticatedRequest(callInfo, client);
                this.AssertLocalizedRequest(callInfo, client);
                this.AssertSchemaVersionRequest(callInfo, client);
                return new HttpResponse(data, HttpStatusCode.OK, null, null);
            });

            var actual = await client.GetAsync();
            this.AssertJsonObject(expected, actual!);
        }

        protected virtual async Task AssertGetDataAsync<TObject, TId>(IBulkExpandableClient<TObject, TId> client, string file, string idName = "id")
            where TObject : IApiV2Object, IIdentifiable<TId>
        {
            var (data, expected) = this.GetTestData(file);
            var id = this.GetId<TId>(expected[idName]);

            ((IWebApiClientInternal)this.Client).Connection.HttpClient.RequestAsync(Arg.Any<IHttpRequest>(), CancellationToken.None).Returns(callInfo =>
            {
                this.AssertRequest(callInfo, client, $"/{id!.ToString()}");
                this.AssertAuthenticatedRequest(callInfo, client);
                this.AssertLocalizedRequest(callInfo, client);
                this.AssertSchemaVersionRequest(callInfo, client);
                return new HttpResponse(data, HttpStatusCode.OK, null, null);
            });

            var actual = await client.GetAsync(id);
            this.AssertJsonObject(expected, actual);
        }

        protected virtual async Task AssertAllDataAsync<TObject>(IAllExpandableClient<TObject> client, string file)
            where TObject : IApiV2Object
        {
            var (data, expected) = this.GetTestData(file);
            ((IWebApiClientInternal)this.Client).Connection.HttpClient.RequestAsync(Arg.Any<IHttpRequest>(), CancellationToken.None).Returns(callInfo =>
            {
                this.AssertRequest(callInfo, client, "?ids=all");
                this.AssertAuthenticatedRequest(callInfo, client);
                this.AssertLocalizedRequest(callInfo, client);
                this.AssertSchemaVersionRequest(callInfo, client);
                return new HttpResponse(data, HttpStatusCode.OK, null, null);
            });

            var actual = await client.AllAsync();
            this.AssertJsonObject(expected, actual);
        }

        protected virtual async Task AssertBulkDataAsync<TObject, TId>(IBulkExpandableClient<TObject, TId> client, string file, string idName = "id")
            where TObject : IApiV2Object, IIdentifiable<TId>
        {
            var (data, expected) = this.GetTestData(file);
            var ids = this.GetIds<TId>(expected.Select(i =>
            {
                return i is JProperty prop ? prop.Value[idName] : i[idName];
            }));

            ((IWebApiClientInternal)this.Client).Connection.HttpClient.RequestAsync(Arg.Any<IHttpRequest>(), CancellationToken.None).Returns(callInfo =>
            {
                this.AssertRequest(callInfo, client, $"?ids={string.Join(",", ids.Select(i => i?.ToString()))}");
                this.AssertAuthenticatedRequest(callInfo, client);
                this.AssertLocalizedRequest(callInfo, client);
                this.AssertSchemaVersionRequest(callInfo, client);
                return new HttpResponse(data, HttpStatusCode.OK, null, null);
            });

            var actual = await client.ManyAsync(ids);
            this.AssertJsonObject(expected, actual);
        }

        protected virtual async Task AssertIdsDataAsync<TObject, TId>(IBulkExpandableClient<TObject, TId> client, string file)
            where TObject : IApiV2Object, IIdentifiable<TId>
        {
            var (data, expected) = this.GetTestData(file);

            ((IWebApiClientInternal)this.Client).Connection.HttpClient.RequestAsync(Arg.Any<IHttpRequest>(), CancellationToken.None).Returns(callInfo =>
            {
                this.AssertRequest(callInfo, client, string.Empty);
                this.AssertAuthenticatedRequest(callInfo, client);
                this.AssertLocalizedRequest(callInfo, client);
                this.AssertSchemaVersionRequest(callInfo, client);
                return new HttpResponse(data, HttpStatusCode.OK, null, null);
            });

            var actual = await client.IdsAsync();
            this.AssertJsonObject(expected, actual);
        }

        protected virtual void AssertRequest(CallInfo callInfo, IEndpointClient client, string pathAndQuery)
        {
            // Format the URI to how it's supposed to be
            var uri = new Uri(Gw2WebApiV2Client.UrlBase, $"{client.EndpointPath}{pathAndQuery}");
            var parameterProperties = client.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetCustomAttribute<EndpointPathParameterAttribute>() != null);
            if (parameterProperties.Any())
            {
                var builder = new UriBuilder(uri);
                foreach (var parameter in parameterProperties)
                {
                    var attr = parameter.GetCustomAttribute<EndpointPathParameterAttribute>();
                    object value = parameter.GetValue(client);
                    if (value == null)
                        continue;

                    string toAppend = $"{attr.ParameterName}={value}";
                    builder.Query = builder.Query != null && builder.Query.Length > 1
                        ? $"{builder.Query.Substring(1)}&{toAppend}"
                        : toAppend;
                }
                uri = builder.Uri;
            }

            Assert.Equal(uri, callInfo.ArgAt<IHttpRequest>(0).Url);
            var requestHeaders = callInfo.ArgAt<IHttpRequest>(0).RequestHeaders;
            Assert.Contains(new KeyValuePair<string, string>("Accept", "application/json"), requestHeaders);
            Assert.Contains(new KeyValuePair<string, string>("User-Agent", ((IWebApiClientInternal)client).Connection.UserAgent), requestHeaders);
        }

        protected virtual void AssertAuthenticatedRequest(CallInfo callInfo, IEndpointClient client)
        {
            var requestHeaders = callInfo.ArgAt<IHttpRequest>(0).RequestHeaders;
            if (client.IsAuthenticated)
                Assert.Contains(new KeyValuePair<string, string>("Authorization", $"Bearer {((IWebApiClientInternal)client).Connection.AccessToken}"), requestHeaders);
            else
                Assert.DoesNotContain(requestHeaders, h => h.Key == "Authorization");
        }

        protected virtual void AssertLocalizedRequest(CallInfo callInfo, IEndpointClient client)
        {
            var requestHeaders = callInfo.ArgAt<IHttpRequest>(0).RequestHeaders;
            Assert.Contains(new KeyValuePair<string, string>("Accept-Language", ((IWebApiClientInternal)client).Connection.LocaleString), requestHeaders);
        }

        protected virtual void AssertSchemaVersionRequest(CallInfo callInfo, IEndpointClient client)
        {
            var requestHeaders = callInfo.ArgAt<IHttpRequest>(0).RequestHeaders;
            if (!string.IsNullOrWhiteSpace(client.SchemaVersion))
                Assert.Contains(new KeyValuePair<string, string>("X-Schema-Version", client.SchemaVersion), requestHeaders);
            else
                Assert.DoesNotContain(requestHeaders, h => h.Key == "X-Schema-Version");
        }


        protected (string, JToken) GetTestData(string fileResourceName)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Gw2Sharp.Tests.{fileResourceName}"))
            {
                if (stream == null)
                    throw new FileNotFoundException($"Resource {fileResourceName} does not exist");
                using (var reader = new StreamReader(stream))
                {
                    string data = reader.ReadToEnd();
                    return (data, JToken.Parse(data));
                }
            }
        }

        protected T GetId<T>(JToken id) =>
            typeof(T) == typeof(Guid) ? (T)(object)Guid.Parse(id.Value<string>()) : id.Value<T>();

        protected IEnumerable<T> GetIds<T>(IEnumerable<JToken> ids) =>
            typeof(T) == typeof(Guid) ? ids.Select(i => Guid.Parse(i.Value<string>())).Cast<T>() : ids.Select(i => i.Value<T>());


        protected void AssertJsonObject(object expected, object actual)
        {
            switch (expected)
            {
                case JObject jObject:
                    this.AssertJsonObject(jObject, actual);
                    break;
                case JArray jArray:
                    this.AssertJsonObject(jArray, actual);
                    break;
                case JValue jValue:
                    this.AssertJsonObject(jValue, actual);
                    break;
                default:
                    throw new InvalidOperationException($"{nameof(expected)} is not an object, array or value");
            }
        }

        protected void AssertJsonObject(JObject expected, object actual)
        {
            var type = actual.GetType();
            if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(ReadOnlyDictionary<,>) || type.GetGenericTypeDefinition() == typeof(Dictionary<,>)))
            {
                // Dictionary
                var keyType = type.GetGenericArguments()[0];
                var dic = (dynamic)actual;
                foreach (var kvp in expected)
                {
                    string key = string.Concat(kvp.Key.Split('_').Select(s => string.Concat(
                        s[0].ToString().ToUpper(),
                        s.Substring(1))));
                    dynamic property = Convert.ChangeType(key, keyType);
                    if (property == null)
                        throw new InvalidOperationException($"Property {key} does not exist");
                    var actualValue = dic[property];
                    this.AssertJsonObject(kvp.Value, actualValue);
                }
            }
            else
            {
                // Specific object
                foreach (var kvp in expected)
                {
                    string key = string.Concat(kvp.Key.Split('_').Select(s => string.Concat(
                        s[0].ToString().ToUpper(),
                        s.Substring(1))));
                    var property = type.GetProperty(key);
                    if (property == null)
                        throw new InvalidOperationException($"Property {key} does not exist");
                    object actualValue = property.GetValue(actual);
                    this.AssertJsonObject(kvp.Value, actualValue);
                }
            }
        }

        protected void AssertJsonObject(JArray expected, object actual)
        {
            var actualList = (actual as IEnumerable)?.Cast<object>().ToList();
            if (actualList == null)
                throw new InvalidOperationException($"Expected an object that's castable to an enumerable for {expected}");
            for (int i = 0; i < expected.Count; i++)
                this.AssertJsonObject(expected[i], actualList[i]);
        }

        protected void AssertJsonObject(JValue expected, object actual)
        {
            switch (actual)
            {
                case Guid guid:
                    Assert.Equal(new Guid(expected.Value<string>()), guid);
                    break;
                case DateTime dateTime:
                    Assert.Equal(expected.Value<DateTime>(), dateTime);
                    break;
                case TimeSpan timeSpan:
                    Assert.Equal(TimeSpan.FromSeconds(expected.Value<int>()), timeSpan);
                    break;
                case ApiEnum @enum:
                    Assert.Equal(expected.Value<string>(), @enum.RawValue);
                    var typeInfo = @enum.GetType().GetTypeInfo();
                    if (typeInfo.IsGenericType && typeInfo.GenericTypeArguments.Length > 0)
                    {
                        var enumType = typeInfo.GenericTypeArguments[0];
                        if (@enum.IsUnknown)
                        {
                            var enumNames = Enum.GetNames(enumType).Select(x => x.Replace("_", ""));
                            Assert.True(enumNames.Contains(@enum.RawValue, StringComparer.OrdinalIgnoreCase), $"Expected '{expected}' to be a value in enumerator {@enum.Value.GetType().Name}; detected value '{@enum.Value}'");
                        }
                        Assert.Equal(expected.Value<string>().ParseEnum(enumType), @enum.Value);
                    }
                    else
                        throw new InvalidOperationException("Expected a generic ApiEnum");
                    break;
                case int @int:
                    Assert.Equal(Convert.ToInt32(expected.Value), @int);
                    break;
                case double @double:
                    Assert.Equal(Convert.ToDouble(expected.Value), @double, 10);
                    break;
                default:
                    if (((actual != null && !(actual is string)) || actual == null) &&
                        expected.Type == JTokenType.String)
                    {
                        // Special case where the resulting value has been auto deserialized into something else than a string,
                        // while the original is a string.
                        Assert.Equal(expected.Value, actual?.ToString() ?? string.Empty);
                    }
                    else
                        Assert.Equal(expected.Value, actual);
                    break;
            }
        }

        #endregion


        #region ArgumentNullException tests

        [Fact]
        public virtual void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(
                this.Client.GetType(),
                new[] { typeof(IConnection) },
                new[] { new Connection() },
                new[] { true });
        }

        #endregion
    }
}
