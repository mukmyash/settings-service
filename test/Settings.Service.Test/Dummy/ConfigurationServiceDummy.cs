namespace Settings.Service.Test.Dummy;

public class ConfigurationServiceDummy : IConfigurationService
{
    public Dictionary<string, object> Configuration { get; }
    public string ServiceName { get; }

    public ConfigurationServiceDummy(string serviceName, Dictionary<string, object> configuration)
    {
        Configuration = configuration;
        ServiceName = serviceName;
    }

    public ConfigurationServiceDummy(string serviceName)
        : this(serviceName, new Dictionary<string, object>())
    {
    }
}