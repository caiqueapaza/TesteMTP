using System.Text.Json.Serialization;

namespace TesteMTP.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEnum
    {
        Progress
        ,Finished
    }
}
