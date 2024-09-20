using Microsoft.Extensions.DependencyInjection;
using QuartZ.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkRepository
{
    public class Dependens 
    {
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("WorkRepository Dependens");
            services.AddScoped<ISendMessageRepository, SendMessageRepository>();
        }

    }
}
