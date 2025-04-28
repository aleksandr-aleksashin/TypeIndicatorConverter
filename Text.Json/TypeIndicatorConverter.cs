using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using TypeIndicatorConverter.Core;
using TypeIndicatorConverter.TextJson.UnificationHelpers;

namespace TypeIndicatorConverter.TextJson;

public class TypeIndicatorConverter<T> : JsonConverter<T>
{
    private static readonly Lazy<DispatchList<T, JsonElement, JsonSerializerOptions>> DispatchListLazy =
        new(() => DispatchList<T, JsonElement, JsonSerializerOptions>.Create(TextUnificationHelper.Instance.Value), LazyThreadSafetyMode.ExecutionAndPublication);

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (!CanConvert(typeToConvert))
            throw new TypeIndicatorConverterException($"Cannot deserialize the current JSON object into type {typeToConvert}");

        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return default;
            case JsonTokenType.String:
                throw new TypeIndicatorConverterException("This converter does not support string deserialization");
            default:
            {
                using (var jsonDocument = JsonDocument.ParseValue(ref reader))
                {
                    var type = DispatchListLazy.Value.GetMatchedType(jsonDocument.RootElement, options);

                    return (T)JsonSerializer.Deserialize(jsonDocument.RootElement.GetRawText(), type, options);
                }
            }
        }
    }

    /// <remarks>
    /// Using 'TypeIndicatorConverterFactory' and the attribute 'JsonConverter' attached to a non-abstract class or interface leads to a recursive call and exception.
    /// </remarks>
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}