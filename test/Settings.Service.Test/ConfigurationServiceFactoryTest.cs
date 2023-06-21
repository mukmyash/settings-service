using Settings.Service.Test.Extensions;

namespace Settings.Service.Test;

public class ConfigurationServiceFactoryTest
{
    [Fact]
    public void ConfigurationServiceFactory_GetConfigurationService_Success()
    {
        var fakeConfigurationService = A.CollectionOfDummy<IConfigurationService>(10);

        var expectedConfiguration = fakeConfigurationService.GetRandomElement();

        new ConfigurationServiceFactory(fakeConfigurationService)
            .GetConfigurationService(expectedConfiguration.ServiceName)
            .Should()
            .Be(expectedConfiguration);
    }


    [Fact]
    public void ConfigurationServiceFactory_GetConfigurationService_NotFound()
    {
        var fakeConfigurationService = A.CollectionOfDummy<IConfigurationService>(10);

        const string servicename = "NOT INT COLLECTION";
        var callTestMethode = () => new ConfigurationServiceFactory(fakeConfigurationService)
            .GetConfigurationService(servicename);
        callTestMethode.Should().Throw<Exception>()
            .WithMessage($"Конфигурация для сервиса '{servicename}' не найдена");
    }
}