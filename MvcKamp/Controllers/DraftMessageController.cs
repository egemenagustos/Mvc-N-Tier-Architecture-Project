using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class DraftMessageController : Controller
    {
        DraftMessageManager dm = new DraftMessageManager(new EfDraftMessageDal());

        public ActionResult Index()
        {
            var draftMessage = dm.GetDraftMessageList();
            return View(draftMessage);
        }
    }
}