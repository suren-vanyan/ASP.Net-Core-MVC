using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter3_DependencyInjection.Services
{
   public class MessageService
    {
        IMessageSender _sender;
        public MessageService(IMessageSender messageSender)
        {
            _sender = messageSender;
        }
        public string Send()
        {
          return  _sender.Send();
        }
    }
}
