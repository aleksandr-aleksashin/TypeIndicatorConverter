using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using TypeIndicatorConverter.Core.AssertionsAbstraction.Interfaces;

namespace TypeIndicatorConverter.TextJson.UnificationHelpers
{
    internal class TextUnificationHelper : IUnificationHelper<JsonElement, JsonSerializerOptions>
    {
        public static readonly Lazy<TextUnificationHelper> Instance = new(() => new TextUnificationHelper(), LazyThreadSafetyMode.ExecutionAndPublication);

        private TextUnificationHelper() { }

        public string? GetAsString(JsonElement element, JsonSerializerOptions settings) => element.GetString();

        public bool TryGetField(string name, JsonElement element, out JsonElement result) => element.TryGetProperty(name, out result);

        public bool IsNullToken(JsonElement element) => element.ValueKind == JsonValueKind.Null;

        public bool IsUndefinedToken(JsonElement element) => element.ValueKind == JsonValueKind.Undefined;

        public string? GetNameDefinedByAttributes(PropertyInfo propertyInfo, Type baseType) => propertyInfo.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name;

        public IEnumerable<string> GetPossibleFieldName(JsonElement element, string basePropertyName, JsonSerializerOptions options)
        {
            var name = basePropertyName;

            if (options.PropertyNamingPolicy is not null)
            {
                name = options.PropertyNamingPolicy.ConvertName(basePropertyName);
            }

            if (options.PropertyNameCaseInsensitive)
            {
                foreach (var jsonProperty in element.EnumerateObject().Where(p => string.Compare(p.Name, name, StringComparison.OrdinalIgnoreCase) == 0))
                {
                    yield return jsonProperty.Name;
                }

                yield break;
            }

            yield return name;
        }
        public bool TryDeserialize(JsonElement element, JsonSerializerOptions settings, Type? type, out object result)
        {
            result = null;

            try
            {
                result = JsonSerializer.Deserialize(element.GetRawText(), type, settings);

                return true;
            }
            catch (Exception)
            {
                //ignore
            }

            return false;
        }
    }
}
