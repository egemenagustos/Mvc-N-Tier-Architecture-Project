using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var heading = hm.GetHeadingList();
            return View(heading);
        }

        public ActionResult HeadingReport()
        {
            var heading = hm.GetHeadingList();
            return View(heading);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Value = x.CategoryID.ToString(),
                                                      Text = x.CategoryName
                                                  }).ToList();
            ViewBag.valCategory = valueCategory;


            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Value = x.WriterID.ToString(),
                                                      Text = x.WriterName + " " + x.WriterSurname
                                                  }).ToList();
            ViewBag.valWriter = valueWriter;


            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Value = x.CategoryID.ToString(),
                                                      Text = x.CategoryName
                                                  }).ToList();
            ViewBag.valCategory = valueCategory;

            var values = hm.GetById(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var values = hm.GetById(id);
            if(values.HeadingStatus == true)
            {
                values.HeadingStatus = false;
                hm.HeadingDelete(values);
                return RedirectToAction("Index");
            }
            else if(values.HeadingStatus == false)
            {
                values.HeadingStatus = true;
                hm.HeadingDelete(values);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}