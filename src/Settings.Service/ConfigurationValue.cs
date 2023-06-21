using System.Text.Json.Serialization;

namespace Settings.Service;

[JsonConverter(typeof(ConfigurationValueJsonConverter))]
public class ConfigurationValue
{
    public string Value { get; set; }

    public ConfigurationValue(string value)
    {
        Value = value;
    }

    public static explicit operator ConfigurationValue(string value) => new ConfigurationValue(value);
}