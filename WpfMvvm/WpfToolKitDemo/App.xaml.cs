using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfToolKitDemo.Services;
using WpfToolKitDemo.ViewModels;
using WpfToolKitDemo.Views;

namespace WpfToolKitDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; }

        public static new App Current => (App)Application.Current;

        public App()
        {
            var container = new ServiceCollection();

            container.AddSingleton<NavigationTulingService>();
            container.AddSingleton<UserService>();

            container.AddTransient<Navigator1ViewModel>();
            container.AddTransient<Navigator2ViewModel>();

            Services = container.BuildServiceProvider();
        }
    }



    public interface IFileService
    {
        void Save();
    }

   public class FileService : IFileService
    {
        public void Save()
        {
            Debug.WriteLine("Line");
        }
    }
}
