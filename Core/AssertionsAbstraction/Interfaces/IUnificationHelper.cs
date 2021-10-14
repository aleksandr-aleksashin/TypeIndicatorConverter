#nullable enable
using System;
using System.Collections.Generic;
using System.Reflection;

namespace TypeIndicatorConverter.Core.AssertionsAbstraction.Interfaces
{
    public interface IUnificationHelper<TElement, TSettings>
    {
        public string GetAsString(TElement element, TSettings settings);

        public bool TryGetField(string name, TElement element, out TElement result);

        public bool IsNullToken(TElement element);

        public bool IsUndefinedToken(TElement element);

        public string? GetNameDefinedByAttributes(PropertyInfo propertyInfo, Type baseType);

        public IEnumerable<string> GetPossibleFieldName(TElement element, string basePropertyName, TSettings options);

        public bool TryDeserialize(TElement element, TSettings settings, Type? type, out object result);
    }
}
