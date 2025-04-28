using System;

namespace TypeIndicatorConverter.Core.Attribute;

[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = false)]
public class AmbiguousMatchingAttribute : System.Attribute
{
    public bool AllowMultiplySelection { get; }

    public AmbiguousMatchingAttribute(bool allowMultiplySelection = false)
    {
        AllowMultiplySelection = allowMultiplySelection;
    }
}