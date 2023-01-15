using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class DraftMessageManager : IDraftMessageService
    {
        IDraftMessageDal _draftMessageDal;

        public DraftMessageManager(IDraftMessageDal draftMessageDal)
        {
            _draftMessageDal = draftMessageDal;
        }

        public void DraftMessageAdd(DraftMessage draftMessage)
        {
            _draftMessageDal.Insert(draftMessage);
        }

        public void DraftMessageDelete(DraftMessage draftMessage)
        {
            _draftMessageDal.Delete(draftMessage);
        }

        public void DraftMessageUpdate(DraftMessage draftMessage)
        {
            _draftMessageDal.Update(draftMessage);
        }

        public DraftMessage GetById(int id)
        {
            return _draftMessageDal.Get(x => x.DraftMessageID == id);
        }

        public List<DraftMessage> GetDraftMessageList()
        {
            return _draftMessageDal.List();
        }
    }
}
