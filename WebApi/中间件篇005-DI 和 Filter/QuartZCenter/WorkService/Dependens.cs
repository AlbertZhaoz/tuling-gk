using QuartZ.Core;
using Microsoft.Extensions.DependencyInjection;


namespace WorkService
{
    public class Dependens : IRDYDependencyInjection
    {
        public void ConfigureServices(IServiceCollection services)
        {
            System.Console.WriteLine("WorkService Dependens");
            services.AddScoped<ISendMessageService, SendMessageService>();
            services.AddScoped(typeof(ISendMessageService), typeof(SendMessageService));
        }

    }
}
