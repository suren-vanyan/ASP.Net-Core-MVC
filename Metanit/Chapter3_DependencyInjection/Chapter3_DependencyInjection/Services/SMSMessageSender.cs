using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter3_DependencyInjection.Services
{
    public class SMSMessageSender : IMessageSender
    {
        public string Send()
        {
            return "Send By SMS";
        }
    }
}
