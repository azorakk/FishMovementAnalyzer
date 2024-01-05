using FishMovementAnalyzerApp.Library.FileHandler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FishMovementAnalyzerApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        /// Create a host builder to build the service provider
        /// </summary>
        /// <returns></returns>
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IFileHandler, FileHandler>();
                    //services.AddScoped<TInterface, TImplementation>();
                    services.AddTransient<Form1>();
                });
        }

    }
}