using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using TypeIndicatorConverter.Core;

namespace TypeIndicatorConverter.TextJson
{
    [ExcludeFromCodeCoverage]
    public class TypeIndicatorConverterFactory : JsonConverterFactory
    {
        private static readonly Lazy<TypeIndicatorConverterFactory> _instance = new(() => new TypeIndicatorConverterFactory(), LazyThreadSafetyMode.ExecutionAndPublication);
        public static TypeIndicatorConverterFactory Instance => _instance.Value;

        private TypeIndicatorConverterFactory()
        {
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.GetCustomAttribute<JsonConverterAttribute>()?.ConverterType?.GetGenericTypeDefinition() == typeof(TypeIndicatorConverter<>);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            if (!CanConvert(typeToConvert))
            {
                throw new TypeIndicatorConverterException($"{typeToConvert} is not a valid type for converter {typeof(TypeIndicatorConverter<>)}");
            }

            return (JsonConverter)Activator.CreateInstance(typeof(TypeIndicatorConverter<>).MakeGenericType(typeToConvert));
        }
    }
}
