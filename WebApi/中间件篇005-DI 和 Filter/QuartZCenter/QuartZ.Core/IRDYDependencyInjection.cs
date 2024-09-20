using Microsoft.Extensions.DependencyInjection;

namespace QuartZ.Core
{
    public interface IRDYDependencyInjection
    {
        void ConfigureServices(IServiceCollection services);
    }
    public interface IDIScoped
    {
    }
    public interface IDISingleton
    {
    }
    public interface IDITransient
    {
    }
}
