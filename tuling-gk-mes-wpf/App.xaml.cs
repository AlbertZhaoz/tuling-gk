using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WpfTulingGkMes.Helpers;
using WpfTulingGkMes.Models;
using WpfTulingGkMes.Views;

namespace WpfTulingGkMes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitConfig();
            Services = ConfigureServices();
            InitializeComponent();
        }

        private void InitConfig()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("Configs//appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            ConfigHelper.Instance.WebUriProp = configuration.GetSection("WebUri").Get<WebUri>();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            return services.BuildServiceProvider();
        }
    }
}
