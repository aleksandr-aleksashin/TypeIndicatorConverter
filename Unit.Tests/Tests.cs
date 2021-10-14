using System.Text.Json;
using DashaAI.TypeIndicatorConverter.Unit.Tests.AllowAny;
using DashaAI.TypeIndicatorConverter.Unit.Tests.AnyNullHandle;
using DashaAI.TypeIndicatorConverter.Unit.Tests.DataMemberName;
using DashaAI.TypeIndicatorConverter.Unit.Tests.FallBackIndicator;
using DashaAI.TypeIndicatorConverter.Unit.Tests.JsonPropertyName;
using DashaAI.TypeIndicatorConverter.Unit.Tests.MultiplyIndicators;
using DashaAI.TypeIndicatorConverter.Unit.Tests.NamingAttributes;
using DashaAI.TypeIndicatorConverter.Unit.Tests.NotParameterLessConstructor;
using DashaAI.TypeIndicatorConverter.Unit.Tests.NoTypeIndicators;
using DashaAI.TypeIndicatorConverter.Unit.Tests.TestMultiplyAllowed;
using DashaAI.TypeIndicatorConverter.Unit.Tests.TestMultiplyDeallowed;
using TypeIndicatorConverter.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests
{
    public class Tests
    {
        [Fact]
        public void TestNamingAttributes()
        {
            Assert.IsType<NamingAttributesTest>(JsonConvert
                                                    .DeserializeObject<NamingAttributesBaseTest>(@$"{{""Type"":""Type"", ""Type_0"":""Type0"", ""Type1"":""Type1"",""Type_2"":""Type2""}}"));

            Assert.IsType<NamingAttributesTest>(JsonSerializer
                                                    .Deserialize<NamingAttributesBaseTest>(@$"{{""Type"":""Type"", ""Type0"":""Type0"", ""Type1"":""Type1"",""Type_2"":""Type2""}}"));

            var textJsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var newtonsoftJsonOptions = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            };

            Assert.IsType<NamingAttributesTest1>(JsonConvert
                                                     .DeserializeObject<NamingAttributesBaseTest>(@$"{{""type7"":""Type7"",""type8"":null,""type9"":null,""Type_10"":null}}", newtonsoftJsonOptions));

            Assert.IsType<NamingAttributesTest1>(JsonSerializer
                                                     .Deserialize<NamingAttributesBaseTest>(@$"{{""type7"":""Type7"",""type8"":null,""type9"":null,""Type_10"":null}}", textJsonOptions));

            var textCaseInsensitiveJsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
            };

            Assert.IsType<NamingAttributesTest2>(JsonSerializer
                                                     .Deserialize<NamingAttributesBaseTest>(@$"{{""Type11"":""Type11""}}", textCaseInsensitiveJsonOptions));

            Assert.IsType<NamingAttributesTest2>(JsonSerializer
                                                     .Deserialize<NamingAttributesBaseTest>(@$"{{""type11"":""Type11""}}", textCaseInsensitiveJsonOptions));

            Assert.IsType<NamingAttributesTest2>(JsonSerializer
                                                     .Deserialize<NamingAttributesBaseTest>(@$"{{""tyPe11"":""Type11""}}", textCaseInsensitiveJsonOptions));
        }

        [Fact]
        public void TestJsonPropertyAttribute()
        {
            Assert.IsType<JsonPropertyNameTest1>(JsonConvert.DeserializeObject<JsonPropertyNameTest1>(JsonConvert.SerializeObject(new JsonPropertyNameTest1())));
            Assert.IsType<JsonPropertyNameTest1>(JsonSerializer.Deserialize<JsonPropertyNameTest1>(JsonSerializer.Serialize(new JsonPropertyNameTest1())));

            Assert.IsType<JsonPropertyNameTest1>(JsonConvert.DeserializeObject<JsonPropertyNameBaseTest>(JsonConvert.SerializeObject(new JsonPropertyNameTest1())));
            Assert.IsType<JsonPropertyNameTest1>(JsonSerializer.Deserialize<JsonPropertyNameBaseTest>(JsonSerializer.Serialize(new JsonPropertyNameTest1())));

            Assert.IsType<JsonPropertyNameTest1>(JsonConvert.DeserializeObject<JsonPropertyNameBaseTest>($@"{{""Type_"":""Type""}}"));
            Assert.IsType<JsonPropertyNameTest1>(JsonSerializer.Deserialize<JsonPropertyNameBaseTest>($@"{{""Type_"":""Type""}}"));

            // ignore data member because jsonPropertyAttribute have higher priority
            Assert.IsType<JsonPropertyNameTest2>(JsonConvert.DeserializeObject<JsonPropertyNameBaseTest>($@"{{""Type_"":""Type2""}}"));
            Assert.IsType<JsonPropertyNameTest2>(JsonSerializer.Deserialize<JsonPropertyNameBaseTest>($@"{{""Type_"":""Type2""}}"));
            Assert.Throws<TypeIndicatorConverterException>(() => JsonConvert.DeserializeObject<JsonPropertyNameBaseTest>($@"{{""Type_1"":""Type2""}}"));
            Assert.Throws<TypeIndicatorConverterException>(() => JsonSerializer.Deserialize<JsonPropertyNameBaseTest>($@"{{""Type_1"":""Type2""}}"));
        }

        [Fact]
        public void TestDataMemberAttribute()
        {
            // serialize/deserialize concrete class
            Assert.IsType<DataMemberNameTest2>(JsonConvert.DeserializeObject<DataMemberNameTest2>(JsonConvert.SerializeObject(new DataMemberNameTest2())));
            Assert.IsType<DataMemberNameTest2>(JsonSerializer.Deserialize<DataMemberNameTest2>(JsonSerializer.Serialize(new DataMemberNameTest2())));
            // serialize/deserialize base class only for newtonsoft
            Assert.IsType<DataMemberNameTest2>(JsonConvert.DeserializeObject<DataMemberNameBaseTest>(JsonConvert.SerializeObject(new DataMemberNameTest2())));
            Assert.Throws<TypeIndicatorConverterException>(() => JsonSerializer.Deserialize<DataMemberNameBaseTest>(JsonSerializer.Serialize(new DataMemberNameTest2())));
            // worked data member only for newtonsoft
            Assert.IsType<DataMemberNameTest2>(JsonConvert.DeserializeObject<DataMemberNameBaseTest>($@"{{""Type_"":""Type""}}"));
            Assert.Throws<TypeIndicatorConverterException>(() => JsonSerializer.Deserialize<DataMemberNameBaseTest>($@"{{""Type_"":""Type""}}"));

            Assert.IsType<DataMemberNameTest1>(JsonConvert.DeserializeObject<DataMemberNameBaseTest>($@"{{""Type"":""Type""}}"));
            // ambiguous because ignored data member
            Assert.Throws<TypeIndicatorConverterException>(() => JsonSerializer.Deserialize<DataMemberNameBaseTest>($@"{{""Type"":""Type""}}"));
        }

        [Fact]
        public void TestAnyNullValue()
        {
            Assert.IsType<AnyNullHandleTest3>(JsonConvert
                                                  .DeserializeObject<AnyNullHandleBaseTest>(@$"{{""Type1"":""Type1"",""Type2"":""Type2""}}"));

            Assert.IsType<AnyNullHandleTest3>(JsonSerializer
                                                  .Deserialize<AnyNullHandleBaseTest>(@$"{{""Type1"":""Type1"",""Type2"":""Type2""}}"));
        }

        [Fact]
        public void TestMultiplyAllowedAttributes()
        {
            Assert.IsType<MultiplyAllowedTest1>(JsonConvert.DeserializeObject<MultiplyAllowedBaseTest>(@$"{{""Test"":""Test""}}"));
            Assert.IsType<MultiplyAllowedTest1>(JsonSerializer.Deserialize<MultiplyAllowedBaseTest>(@$"{{""Test"":""Test""}}"));
        }

        [Fact]
        public void TestMultiplyDeAllowedAttributes()
        {
            Assert.Throws<TypeIndicatorConverterException>(() => JsonConvert.DeserializeObject<MultiplyDeAllowedBaseTest>(@$"{{""Test"":""Test""}}"));
            Assert.Throws<TypeIndicatorConverterException>(() => JsonSerializer.Deserialize<MultiplyDeAllowedBaseTest>(@$"{{""Test"":""Test""}}"));
        }

        [Fact]
        public void TestNoTypeIndicators()
        {
            Assert.Throws<TypeIndicatorConverterException>(() => JsonConvert.DeserializeObject<NoTypeIndicatorsBaseTest>(@$"{{""Test"":""Test""}}"));
            Assert.Throws<TypeIndicatorConverterException>(() => JsonSerializer.Deserialize<NoTypeIndicatorsBaseTest>(@$"{{""Test"":""Test""}}"));
        }

        [Fact]
        public void TestFallBackIndicator()
        {
            Assert.IsType<FallBackIndicatorTest1>(JsonConvert.DeserializeObject<FallBackIndicatorBaseTest>(@$"{{""Type3"":""Type3""}}"));
            Assert.IsType<FallBackIndicatorTest1>(JsonSerializer.Deserialize<FallBackIndicatorBaseTest>(@$"{{""Type3"":""Type3""}}"));
            Assert.IsType<FallBackIndicatorTest2>(JsonConvert.DeserializeObject<FallBackIndicatorBaseTest>(@$"{{""Type1"":""Type1""}}"));
            Assert.IsType<FallBackIndicatorTest2>(JsonSerializer.Deserialize<FallBackIndicatorBaseTest>(@$"{{""Type1"":""Type1""}}"));
        }

        [Fact]
        public void TestNotParameterLessConstructor()
        {
            Assert.Throws<TypeIndicatorConverterException>(() => JsonConvert.DeserializeObject<NotParameterLessConstructorBaseTest>(@$"{{""Test"":""Test""}}"));
            Assert.Throws<TypeIndicatorConverterException>(() => JsonSerializer.Deserialize<NotParameterLessConstructorBaseTest>(@$"{{""Test"":""Test""}}"));
        }

        [Fact]
        public void TestNullOrStringObjectConstructor()
        {
            Assert.Null(JsonConvert.DeserializeObject<FallBackIndicatorBaseTest>(@$"null"));
            Assert.Null(JsonSerializer.Deserialize<FallBackIndicatorBaseTest>(@$"null"));
            Assert.Throws<TypeIndicatorConverterException>(() => JsonConvert.DeserializeObject<FallBackIndicatorBaseTest>(@$"""asd"""));
            Assert.Throws<TypeIndicatorConverterException>(() => JsonSerializer.Deserialize<FallBackIndicatorBaseTest>(@$"""asd"""));
        }

        [Fact]
        public void TestNoMatchedType()
        {
            Assert.Throws<TypeIndicatorConverterException>(() => JsonConvert.DeserializeObject<NamingAttributesBaseTest>(@$"{{}}"));
            Assert.Throws<TypeIndicatorConverterException>(() => JsonSerializer.Deserialize<NamingAttributesBaseTest>(@$"{{}}"));
        }

        [Fact]
        public void TestMultiplyIndicators()
        {
            Assert.IsType<MultiplyIndicatorsTest2>(JsonConvert.DeserializeObject<MultiplyIndicatorsBaseTest>(@$"{{""Type1"":""Type1"", ""Type2"":2}}"));
            Assert.IsType<MultiplyIndicatorsTest2>(JsonSerializer.Deserialize<MultiplyIndicatorsBaseTest>(@$"{{""Type1"":""Type1"", ""Type2"":2}}"));
            Assert.IsType<MultiplyIndicatorsTest1>(JsonConvert.DeserializeObject<MultiplyIndicatorsBaseTest>(@$"{{""Type1"":""Type1"", ""Type2"":3}}"));
            Assert.IsType<MultiplyIndicatorsTest1>(JsonSerializer.Deserialize<MultiplyIndicatorsBaseTest>(@$"{{""Type1"":""Type1"", ""Type2"":3}}"));
        }

        [Fact]
        public void TestUnknownValue()
        {
            Assert.IsType<UnknownValueTest1>(JsonConvert.DeserializeObject<UnknownValueBaseTest>(@$"{{""Type1"":""Type1"", ""Type2"": 2}}"));
            Assert.IsType<UnknownValueTest1>(JsonSerializer.Deserialize<UnknownValueBaseTest>(@$"{{""Type1"":""Type1"", ""Type2"": 2}}"));

            Assert.IsType<UnknownValueTest1>(JsonConvert.DeserializeObject<UnknownValueBaseTest>(@$"{{""Type1"":""Type1"", ""Type2"": 5}}"));
            Assert.IsType<UnknownValueTest1>(JsonSerializer.Deserialize<UnknownValueBaseTest>(@$"{{""Type1"":""Type1"", ""Type2"": 5}}"));

            Assert.IsType<UnknownValueTest1>(JsonConvert.DeserializeObject<UnknownValueBaseTest>(@$"{{""Type1"":""Type1"", ""Type2"": null}}"));
            Assert.IsType<UnknownValueTest1>(JsonSerializer.Deserialize<UnknownValueBaseTest>(@$"{{""Type1"":""Type1"", ""Type2"": null}}"));

            Assert.IsType<UnknownValueTest1>(JsonConvert.DeserializeObject<UnknownValueBaseTest>(@$"{{""Type1"":""Type1"" }}"));
            Assert.IsType<UnknownValueTest1>(JsonSerializer.Deserialize<UnknownValueBaseTest>(@$"{{""Type1"":""Type1""}}"));
        }
    }
}
