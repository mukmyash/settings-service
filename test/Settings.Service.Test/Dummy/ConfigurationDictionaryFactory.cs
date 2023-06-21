namespace Settings.Service.Test.Dummy;

public static class ConfigurationDictionaryFactory
{
    public enum ServiceName
    {
        exampleService
    }

    public enum Environment
    {
        Development,
        KB1
    }

    public static IDictionary<string, object> GetConfiguration(ServiceName servicename, Environment environment)
        => environment switch
        {
            Environment.KB1 => GetExampleServiceKB1Configuration(),
            _ => throw new Exception($"Конфигурации для окружения {environment} не существует ")
        };

    private static IDictionary<string, object> GetExampleServiceKB1Configuration()
    {
        var result = new Dictionary<string, object>()
        {
            {
                "Variables", new Dictionary<string, object>()
                {
                    {
                        "ConnectionStrings", new Dictionary<string, object>()
                        {
                            { "Server", (ConfigurationValue)"kb1-server" },
                            { "Password", (ConfigurationValue)"kb1-pass" },
                            { "Login", (ConfigurationValue)"kb1-login" }
                        }
                    }
                }
            },
            { "variable2", (ConfigurationValue)"Service Variable 2" },
            { "variable1", (ConfigurationValue)"Service Variable 1" },
            {
                "useVariable1And2",
                (ConfigurationValue)"value from variable 1 'Service Variable 1' and variable 2 'Service Variable 2'"
            },
            { "useVariable1", (ConfigurationValue)"value from variable 1'Service Variable 1'" },
            {
                "useValueOtherVariable",
                (ConfigurationValue)
                "value from useVariable1And2 'value from variable 1 'Service Variable 1' and variable 2 'Service Variable 2''"
            },
            { "override-shared-value", (ConfigurationValue)"Service KB1" },
            {
                "ConnectionStrings", new Dictionary<string, object>()
                {
                    { "DataBase", (ConfigurationValue)"Server: kb1-server, Login = kb1-login, Password=kb1-pass" }
                }
            }
        };

        return result;
    }
}