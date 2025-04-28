using System;

namespace TypeIndicatorConverter.Core.Attribute;

[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = false)]
public class IgnoreIndicatorsAttribute : System.Attribute
{
}