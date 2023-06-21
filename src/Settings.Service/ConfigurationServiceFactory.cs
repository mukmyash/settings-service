namespace Settings.Service;

public class ConfigurationServiceFactory : IConfigurationServiceFactory
{
    private readonly IDictionary<string, IConfigurationService> _configurationServices;

    public ConfigurationServiceFactory(IEnumerable<IConfigurationService> configurationServices)
    {
        _configurationServices = configurationServices
            .ToDictionary(
                k => k.ServiceName,
                v => v);
    }

    public IConfigurationService GetConfigurationService(string servicename)
    {
        if (!_configurationServices.TryGetValue(servicename, out var configurationService))
        {
            throw new Exception($"Конфигурация для сервиса '{servicename}' не найдена");
        }

        return configurationService;
    }
}