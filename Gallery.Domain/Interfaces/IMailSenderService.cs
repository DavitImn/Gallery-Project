using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Domain.Interfaces
{
    public interface IMailSenderService
    {
        void Send(string sendTo, string subject, string body);
    }
}