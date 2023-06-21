namespace Settings.Service;

public interface IConfigurationServiceFactory
{
    IConfigurationService GetConfigurationService(string servicename);
}