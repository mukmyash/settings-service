using Settings.Service.Test.Dummy;

namespace Settings.Service.Test;

public class ConfigurationServiceTest
{
    [Fact]
    public void ConfigurationService_ServiceName_Success()
    {
        string serviceName = new Faker().System.FileName();

        new ConfigurationService(serviceName, "KB1")
            .ServiceName.Should().Be(serviceName);
    }

    [Fact]
    public void ConfigurationService_Configuration_Success()
    {
        string serviceName = "example-service";

        new ConfigurationService(serviceName, "KB1")
            .Configuration.Should().BeEquivalentTo(ConfigurationDictionaryFactory.GetConfiguration(
                ConfigurationDictionaryFactory.ServiceName.exampleService,
                ConfigurationDictionaryFactory.Environment.KB1));
    }
}