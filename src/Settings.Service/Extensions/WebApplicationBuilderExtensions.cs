namespace Settings.Service.Extensions;

/// <summary>
/// Расширения для <see cref="WebApplicationBuilder"/>
/// </summary>
public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder
            .RegisterConfiguretionService()
            .Services.AddSingleton<IConfigurationServiceFactory, ConfigurationServiceFactory>();

        return builder;
    }

    private static WebApplicationBuilder RegisterConfiguretionService(this WebApplicationBuilder builder)
    {
        // Регистрируем все конфигурации
        Directory
            .GetDirectories("./Configs")
            .ForEach(folderPath =>
            {
                var folderName = Path
                    // На самом деле мы получаем наименование папки 
                    .GetFileName(folderPath)
                    .CheckFolderName(folderPath);


                builder.Services
                    .AddSingleton<IConfigurationService, ConfigurationService>((_) =>
                        new ConfigurationService(folderName, builder.Environment.EnvironmentName));
            });

        return builder;
    }
}