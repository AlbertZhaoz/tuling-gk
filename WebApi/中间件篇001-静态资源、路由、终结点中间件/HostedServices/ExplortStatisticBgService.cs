using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using NET_FiveMinutes_008_UseIdentity.Models;

namespace NET_FiveMinutes_008_UseIdentity.HostedServices
{
    public class ExplortStatisticBgService:BackgroundService
    {
        private readonly ILogger<ExplortStatisticBgService> _logger;
        private readonly IServiceScope _scope;
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;

        /// <summary>
        /// 由于托管服务是以单例的生命周期注册到依赖注入容器中,按照依赖注入容器的要求
        /// 长生命周期的服务不能依赖短生命周期的服务
        /// 如果我们通过构造函数的方法直接注入EF Core上下文的话,程序会抛异常
        /// 因为通过AddDbContext注册的服务的生命周期是范围的.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="scopeFactory"></param>
        public ExplortStatisticBgService(ILogger<ExplortStatisticBgService> logger, IServiceScopeFactory scopeFactory)
        {
            this._logger = logger;
            this._scope = scopeFactory.CreateScope();
            var sp = _scope.ServiceProvider;
            this.roleManager = sp.GetRequiredService<RoleManager<Role>>();
            this.userManager = sp.GetRequiredService<UserManager<User>>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await DoExecuteAsync();
                    await Task.Delay(2000);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex.Message);
                    await Task.Delay(2000);
                }
            }
        }

        private async Task DoExecuteAsync()
        {
            var user = await userManager.FindByNameAsync("albert");

            if(user != null)
            {
                await File.WriteAllTextAsync($"{AppDomain.CurrentDomain.BaseDirectory}Configs\\test.txt",JsonSerializer.Serialize(user));
            }
        }
    }
}
