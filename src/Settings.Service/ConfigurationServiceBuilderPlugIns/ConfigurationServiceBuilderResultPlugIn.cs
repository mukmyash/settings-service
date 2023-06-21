namespace Settings.Service.ConfigurationServiceBuilderPlugIns;

public class ConfigurationServiceBuilderResultPlugIn : IConfigurationServiceBuilderPlugIn
{
    private readonly Dictionary<string, object> result = new();
    
    public void InsertValue(string path, in ConfigurationValue value)
    {
        InsertValue(result, new Queue<string>(path.Split(":")), value);
    }

    public Dictionary<string, object> GetResult() => result;

    private void InsertValue(Dictionary<string, object> collection, Queue<string> path, in ConfigurationValue value)
    {
        var key = path.Dequeue();
        if (path.Count == 0)
        {
            collection.Add(key, value);
            return;
        }

        if (!collection.TryGetValue(key, out var innerValue))
        {
            innerValue = new Dictionary<string, object>();
            collection.Add(key, innerValue);
        }

        var innerCollection = innerValue as Dictionary<string, object>;
        if (innerCollection == null)
        {
            throw new ArgumentException($"{key} дублирующийся ключ.");
        }

        InsertValue(innerCollection, path, value);
    }
}