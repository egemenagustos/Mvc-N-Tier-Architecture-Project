using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var headinglist = hm.GetHeadingList();
            return View(headinglist);
        }

        public PartialViewResult Index(int id = 0)
        {
            var contentlist = cm.GetByID(id);
            return PartialView(contentlist);
        }
    }
}