using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();

        public ActionResult Index()
        {
            var values = cm.GetContactList();
            return View(values);
        }

        public ActionResult GetContactDetails(int id)
        {
            var values = cm.GetById(id);
            values.ContactStatus = true;
            cm.ContactUpdate(values);
            return View(values);
        }

        public PartialViewResult ContactSidebarPartial()
        {
            var contactCount = cm.GetContactList().Count(x=>x.ContactStatus == false);
            ViewBag.contactCount = contactCount;

            //var sendBox = mm.GetMessageListSendebox().Count();
            //ViewBag.sendBox = sendBox;

           // var receiverBox = mm.GetMessageListInbox().Count(x=>x.MessageStatus==false);
           // ViewBag.receiverBox = receiverBox; 

            return PartialView();
        }
    }
}