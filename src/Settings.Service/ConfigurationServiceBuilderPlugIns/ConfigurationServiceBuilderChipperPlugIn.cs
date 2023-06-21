namespace Settings.Service.ConfigurationServiceBuilderPlugIns;

public class ConfigurationServiceBuilderChipperPlugIn : IConfigurationServiceBuilderPlugIn
{
    private readonly IConfigurationServiceBuilderPlugIn _next;

    public ConfigurationServiceBuilderChipperPlugIn(IConfigurationServiceBuilderPlugIn next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public void InsertValue(string path, in ConfigurationValue value)
    {
        if (value.Value.StartsWith("{cipher}"))
        {
            // TODO: Реализовать алгоритм дешифрования настройки
        }

        _next.InsertValue(path, value);
    }

    public Dictionary<string, object> GetResult() => _next.GetResult();
}