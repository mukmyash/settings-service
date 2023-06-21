namespace Settings.Service.ConfigurationServiceBuilderPlugIns;

public interface IConfigurationServiceBuilderPlugIn
{
    void InsertValue(string path, in ConfigurationValue value);
    Dictionary<string, object> GetResult();
}