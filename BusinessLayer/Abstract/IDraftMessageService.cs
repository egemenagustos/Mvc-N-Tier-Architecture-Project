using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IDraftMessageService
    {
        List<DraftMessage> GetDraftMessageList();

        void DraftMessageAdd(DraftMessage draftMessage);

        DraftMessage GetById(int id);

        void DraftMessageDelete(DraftMessage draftMessage);

        void DraftMessageUpdate(DraftMessage draftMessage);
    }
}
