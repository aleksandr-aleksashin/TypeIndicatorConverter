#nullable enable
using System;
using System.Reflection;
using TypeIndicatorConverter.Core.AssertionsAbstraction.Interfaces;
using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Core.AssertionsAbstraction;

internal class AssertionCondition<TElement, TSettings> : IAssertionCondition<TElement, TSettings>
{
    private readonly ComparingOptions _comparingOptions;
    private readonly string _basePropertyName;
    private readonly string? _propertyNameAttributed;
    private readonly object? _value;
    private readonly Type _baseType;
    private readonly PropertyInfo _propertyInfo;
    private readonly IUnificationHelper<TElement, TSettings> _unificationHelper;
    private readonly TypeIndicatorAttribute? _typeIndicatorAttribute;

    public AssertionCondition(PropertyInfo propertyInfo,
                              TypeIndicatorAttribute typeIndicatorAttribute,
                              object? expectedValue,
                              Type baseType,
                              IUnificationHelper<TElement, TSettings> unificationHelper)
    {
        _typeIndicatorAttribute = typeIndicatorAttribute;
        _propertyInfo = propertyInfo;
        _unificationHelper = unificationHelper;
        _comparingOptions = typeIndicatorAttribute.ComparingOptions;
        _basePropertyName = propertyInfo.Name;
        _value = expectedValue;
        _baseType = baseType;

        _propertyNameAttributed = _unificationHelper.GetNameDefinedByAttributes(propertyInfo, baseType);
    }

    public bool Assert(TElement actualValue, TSettings actualSettings)
    {
        if (_propertyNameAttributed is not null)
        {
            if (_unificationHelper.TryGetField(_propertyNameAttributed, actualValue, out var actualField))
            {
                return _comparingOptions.HasFlag(ComparingOptions.UnknownValue) ? AssertAny(actualField, actualSettings) : AssertEquals(actualField, actualSettings);
            }

            return _comparingOptions.HasFlag(ComparingOptions.AllowNotExist);
        }

        foreach (var fieldName in _unificationHelper.GetPossibleFieldName(actualValue, _basePropertyName, actualSettings))
        {
            if (_unificationHelper.TryGetField(fieldName, actualValue, out var actualField))
            {
                return _comparingOptions.HasFlag(ComparingOptions.UnknownValue) ? AssertAny(actualField, actualSettings) : AssertEquals(actualField, actualSettings);
            }
        }

        return _comparingOptions.HasFlag(ComparingOptions.AllowNotExist);
    }

    private bool AssertAny(TElement actualValue, TSettings actualSettings)
    {
        return !_unificationHelper.IsUndefinedToken(actualValue) || _comparingOptions.HasFlag(ComparingOptions.AllowNotExist);
    }

    private bool AssertEquals(TElement actualValue, TSettings actualSettings)
    {
        switch (_value)
        {
            case null when _unificationHelper.IsNullToken(actualValue):
                return true;
            case null when _unificationHelper.IsUndefinedToken(actualValue) && _comparingOptions.HasFlag(ComparingOptions.AllowNotExist):
                return true;
            case null when _unificationHelper.IsUndefinedToken(actualValue) && !_comparingOptions.HasFlag(ComparingOptions.AllowNotExist):
                return false;
            case null when !_unificationHelper.IsUndefinedToken(actualValue) && !_unificationHelper.IsNullToken(actualValue):
                return false;
            case null:
                return false;
        }

        // TODO: support custom IEqualityComparer, IEqualityComparer<>, IComparer, EqualityComparer<>.Defaults

        if (_value is string)
        {
            return Equals(_unificationHelper.GetAsString(actualValue, actualSettings), _value);
        }

        return _unificationHelper.TryDeserialize(actualValue, actualSettings, _value?.GetType(), out var deserializedActualValue) && Equals(deserializedActualValue, _value);
    }
}