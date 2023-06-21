namespace Settings.Service.Test.Dummy;

public class ConfigurationServiceDummyFactory : DummyFactory<IConfigurationService>
{
    private readonly Faker<ConfigurationServiceDummy> faker =
        new Faker<ConfigurationServiceDummy>()
            .CustomInstantiator(f => new ConfigurationServiceDummy(f.System.FileName()));

    protected override IConfigurationService Create()
    {
        return faker.Generate();
    }
}