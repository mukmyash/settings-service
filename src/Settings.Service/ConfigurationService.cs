namespace Settings.Service;

public class ConfigurationService : IConfigurationService
{
    public Dictionary<string, object> Configuration { get; }
    public string ServiceName { get; }

    public ConfigurationService(string serviceName, string environmentName)
    {
        ServiceName = serviceName;
        Configuration = new ConfigurationServiceBuilder(environmentName)
            .AddApplicationFile()
            .AddServiceNameFile(serviceName)
            .UseChipperPlugIn()
            .UseVariablePlugIn()
            .Build();
    }
}