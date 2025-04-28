using System;

namespace TypeIndicatorConverter.Core;

public class TypeIndicatorConverterException : Exception
{
    public TypeIndicatorConverterException(string message) : base(message)
    {
    }
}