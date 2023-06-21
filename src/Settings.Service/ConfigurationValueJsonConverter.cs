using System.Text.Json;
using System.Text.Json.Serialization;

namespace Settings.Service;

public class ConfigurationValueJsonConverter:JsonConverter<ConfigurationValue>
{
    public override ConfigurationValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, ConfigurationValue value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value);
    }
}