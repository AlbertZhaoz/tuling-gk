using QuartZ.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using WorkRepository;

namespace WorkService
{
    public class SendMessageService : BaseService, ISendMessageService, IDIScoped
    {
        private readonly ISendMessageRepository _sendMessageRepo;
        public SendMessageService(ISendMessageRepository sendMessageRepo)
        {
            _sendMessageRepo = sendMessageRepo;
        }
        public void Send()
        {
            _sendMessageRepo.Test();
        }
      
    }
}
