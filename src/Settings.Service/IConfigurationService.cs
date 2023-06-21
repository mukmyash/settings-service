namespace Settings.Service;

public interface IConfigurationService
{
    Dictionary<string, object> Configuration { get; }
    public string ServiceName { get; }
}