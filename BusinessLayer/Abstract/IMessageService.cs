using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMessageService
    {
        List<Message> GetMessageListInbox(string p);

        List<Message> GetMessageListSendebox(string p);

        void MessageAdd(Message message);

        Message GetById(int id);

        void MessageDelete(Message message);

        void MessageUpdate(Message message);
    }
}
