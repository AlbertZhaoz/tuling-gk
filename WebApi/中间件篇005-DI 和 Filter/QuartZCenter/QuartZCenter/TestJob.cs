using Quartz;
using QuartZ.Core;
using WorkService;

namespace QuartZCenter
{
    internal class TestJob : BaseJob
    {
        private readonly ISendMessageService _iSendMessage;
        
        public TestJob()
        {
            _iSendMessage = GetInstance<ISendMessageService>();
        }

        public override void Excute(IJobExecutionContext context)
        {
            _iSendMessage.Send();
        }

    }
}
