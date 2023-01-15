using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p="")
        {
            var values = cm.GetContentList(p);
            if(values == null)
            {
                cm.GetContentList(p);
            }
            return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            var content = cm.GetByID(id);
            return View(content);
        }
    }
}