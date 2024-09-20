using Quartz;
using QuartZ.Core;
using WorkService;

namespace QuartZCenter
{
    internal class TestJob1 : BaseJob
    {
        private readonly ISendMessageService _iSendMessage;

        public TestJob1()
        {
            _iSendMessage = GetInstance<ISendMessageService>();
        }

        public override void Excute(IJobExecutionContext context)
        {
            //_iSendMessage.Send();
        }
       
    }
}
