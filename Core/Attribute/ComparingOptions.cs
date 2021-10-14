using System;

namespace TypeIndicatorConverter.Core.Attribute
{
    [Flags]
    public enum ComparingOptions
    {
        Default = 0, // Default behavior. Comparison of the field value and the expected value.
        UnknownValue = 1, // Do not compare actual and expected values. Checks only for the presence of a field in an object.
        AllowNotExist = 2, // The absence of a field in the input data is allowed.
    }
}
