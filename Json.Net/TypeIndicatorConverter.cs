#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using TypeIndicatorConverter.Core;
using TypeIndicatorConverter.NewtonsoftJson.UnificationHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TypeIndicatorConverter.NewtonsoftJson
{
    public class TypeIndicatorConverter<T> : JsonConverter<T>
    {
        private static readonly Lazy<DispatchList<T, JToken, JsonSerializer>> DispatchListLazy =
            new(() => DispatchList<T, JToken, JsonSerializer>.Create(NewtonsoftUnificationHelper.Instance.Value), LazyThreadSafetyMode.ExecutionAndPublication);

        public override bool CanWrite => false;

        public override T? ReadJson(JsonReader reader, Type objectType, T? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (objectType != typeof(T))
            {
                var contract = serializer.ContractResolver.ResolveContract(objectType);
                contract.Converter = null;

                return (T)serializer.Deserialize(reader, objectType)!;
            }

            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return default;
                case JsonToken.String:
                    throw new TypeIndicatorConverterException("This converter does not support string deserialization");
                default:
                {
                    var jsonDocument = JObject.Load(reader);

                    var type = DispatchListLazy.Value.GetMatchedType(jsonDocument, serializer);

                    return (T)jsonDocument.ToObject(type, serializer)!;
                }
            }
        }

        [ExcludeFromCodeCoverage]
        public override void WriteJson(JsonWriter writer, T? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
