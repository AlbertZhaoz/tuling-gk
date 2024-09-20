using QuartZ.Core;

namespace QuartZCenter
{
    internal class Program
    {

        static void Main(string[] args)
        {
            IOCCollection.Instance
                         .AddConfigurationSetting()
                         .AddSqlSugar()
                         .AddDependencyInjection(di =>
                         {
                             new WorkService.Dependens().ConfigureServices(di);
                         })
                         .RunIOC()
                         //.RunFullFastQuartZ(jobSetting =>
                         //{
                         //    jobSetting.JobType = typeof(TestJob1);
                         //    jobSetting.JobName = "Test";
                         //})
                         .RunConfigureQuartZ()
                         .BlockCurrentThread()
                         ;
        }
    }
}
