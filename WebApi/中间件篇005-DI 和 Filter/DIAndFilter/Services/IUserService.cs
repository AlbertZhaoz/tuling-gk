using Autofac.Extras.DynamicProxy;
using DotNet实战.AutofacCommon;

namespace DotNet实战.Services
{
    [Intercept(typeof(MyInterceptor))]
    public interface IUserService
    {
        void ShowCode();
    }


    public class UserService : IUserService
    {
        public void ShowCode()
        {
            Console.WriteLine($"UserService.ShowCode:{GetHashCode()}");
        }
    }   
}
