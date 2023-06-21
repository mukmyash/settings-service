using Settings.Service.ConfigurationServiceBuilderPlugIns;
using Settings.Service.Extensions;

namespace Settings.Service;

public class ConfigurationServiceBuilder
{
    private readonly IConfigurationBuilder _configurationRoot = new ConfigurationBuilder();
    private readonly string _environmentName;
    private IConfigurationServiceBuilderPlugIn _plugin = new ConfigurationServiceBuilderResultPlugIn();

    public ConfigurationServiceBuilder(string environmentName)
    {
        _environmentName = environmentName;
    }

    public ConfigurationServiceBuilder AddApplicationFile()
    {
        _configurationRoot
            .AddYamlFile("./Configs/Application.yml", true)
            .AddYamlFile($"./Configs/Application.{_environmentName}.yml", true);

        return this;
    }

    public ConfigurationServiceBuilder AddServiceNameFile(string serviceName)
    {
        _configurationRoot
            .AddYamlFile($"./Configs/{serviceName}/{serviceName}.yml", true)
            .AddYamlFile($"./Configs/{serviceName}/{serviceName}.{_environmentName}.yml", true);

        return this;
    }

    public ConfigurationServiceBuilder UseVariablePlugIn()
    {
        _plugin = new ConfigurationServiceBuilderVariablePlugIn(_plugin);
        return this;
    }

    public ConfigurationServiceBuilder UseChipperPlugIn()
    {
        _plugin = new ConfigurationServiceBuilderChipperPlugIn(_plugin);
        return this;
    }

    public Dictionary<string, object> Build()
    {
        var configurationRoot = _configurationRoot.Build();

        configurationRoot.AsEnumerable()
            .ForEach((kv) =>
            {
                if (kv.Value == null)
                {
                    return;
                }

                var value = new ConfigurationValue(kv.Value);

                _plugin.InsertValue(kv.Key, value);
            });

        return _plugin.GetResult();
    }
}