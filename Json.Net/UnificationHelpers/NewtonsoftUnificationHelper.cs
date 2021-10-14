using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using TypeIndicatorConverter.Core.AssertionsAbstraction.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace TypeIndicatorConverter.NewtonsoftJson.UnificationHelpers
{
    internal class NewtonsoftUnificationHelper : IUnificationHelper<JToken, JsonSerializer>
    {
        public static readonly Lazy<NewtonsoftUnificationHelper> Instance = new(() => new NewtonsoftUnificationHelper(), LazyThreadSafetyMode.ExecutionAndPublication);

        private NewtonsoftUnificationHelper() { }

        public string? GetAsString(JToken element, JsonSerializer settings) => element.Value<string>();

        public bool TryGetField(string name, JToken element, out JToken result)
        {
            result = element.SelectToken(name);

            return result is not null;
        }

        public bool IsNullToken(JToken element) => element.Type == JTokenType.Null;

        public bool IsUndefinedToken(JToken element) => element.Type == JTokenType.Undefined;

        public string? GetNameDefinedByAttributes(PropertyInfo propertyInfo, Type baseType)
        {
            var s = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName;

            if (s != null)
            {
                return s;
            }

            string? name;

            if (baseType.GetCustomAttribute<DataContractAttribute>() is not null)
            {
                name = propertyInfo.GetCustomAttribute<DataMemberAttribute>()?.Name ?? null;
            }
            else
            {
                name = null;
            }

            return name;
        }

        public IEnumerable<string> GetPossibleFieldName(JToken element, string basePropertyName, JsonSerializer options)
        {
            if (options is { ContractResolver: DefaultContractResolver { NamingStrategy: { } } dcr })
            {
                yield return dcr.NamingStrategy.GetPropertyName(basePropertyName, false);

                yield break;
            }

            yield return basePropertyName;
        }

        public bool TryDeserialize(JToken element, JsonSerializer settings, Type? type, out object result)
        {
            result = null;

            try
            {
                result = settings.Deserialize(element.CreateReader(), type);

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
