using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.DataMemberName;

[DataContract()]
[ExcludeFromCodeCoverage]
public class DataMemberNameTest2 : DataMemberNameBaseTest
{
    [TypeIndicator]
    [DataMember(Name = "Type_")]
    public string Type => "Type";
}