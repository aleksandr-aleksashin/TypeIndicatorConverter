using System.Diagnostics.CodeAnalysis;
using TypeIndicatorConverter.TextJson;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.NamingAttributes
{
    #region TestIgnoreAttributes

    [ExcludeFromCodeCoverage]
    [System.Text.Json.Serialization.JsonConverter(typeof(TypeIndicatorConverter<NamingAttributesBaseTest>))]
    [Newtonsoft.Json.JsonConverter(typeof(global::TypeIndicatorConverter.NewtonsoftJson.TypeIndicatorConverter<NamingAttributesBaseTest>))]
    public abstract class NamingAttributesBaseTest
    {
    }

    #endregion

    #region TestAnyNullValue

    #endregion

    #region TestMultiplyAllowedAttributes

    #endregion

    #region TestMultiplyDeAllowedAttributes

    #endregion

    #region TestSerializationDeserialization

    #endregion

    #region TestNoTypeIndicators

    #endregion

    #region TestFallBackIndicator

    #endregion

    #region TestNotParameterLessConstructor

    #endregion

    #region TestMultiplyIndicators

    #endregion

    #region TestAllowAny

    #endregion
}
