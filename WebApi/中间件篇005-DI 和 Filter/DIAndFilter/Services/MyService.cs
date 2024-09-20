namespace DotNet实战.Services
{
    public class MyService: IMyService
    {
        public void ShowCode()
        {
            Console.WriteLine($"MyService.ShowCode:{GetHashCode()}");
        }
    }
    public class MyServiceV2 : IMyService
    {
        public MyNameService NameService { get; set; }
        public void ShowCode()
        {
            Console.WriteLine($"MyServiceV2.ShowCode:{GetHashCode()},NameService 是否为空：{NameService == null}");
        }
    }

    public class MyNameService
    {

    }

    public interface IMyService
    {
        void ShowCode();
    }
}
