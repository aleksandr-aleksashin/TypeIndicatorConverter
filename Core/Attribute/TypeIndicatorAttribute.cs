using System;

namespace TypeIndicatorConverter.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TypeIndicatorAttribute : System.Attribute
    {
        public readonly ComparingOptions ComparingOptions;

        public TypeIndicatorAttribute(ComparingOptions comparingOptions = ComparingOptions.Default)
        {
            ComparingOptions = comparingOptions;
        }
    }
}
