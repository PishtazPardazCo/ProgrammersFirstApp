using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MajorsController : Controller
    {
        private UniContext _db;

        public MajorsController()
        {
            _db = new UniContext();
        }

        public PartialViewResult GetData()
        {
            var major = _db.Majors;

            var modelList = new List<Major>();

            foreach (var rec in major)
            {
                var model = new Major()
                {
                    IdMajor = rec.IdMajor,
                    MajorName = rec.MajorName,
                    Students = rec.Students
                };

                modelList.Add(model);
            }
            ViewBag.ListRecord = modelList;

            return PartialView("List");
        }



        public ActionResult Index()
        {
            var major = _db.Majors;

            var modelList = new List<Major>();

            foreach (var rec in major)
            {
                var model = new Major()
                {
                    IdMajor = rec.IdMajor,
                    MajorName = rec.MajorName,
                    Students = rec.Students
                };

                modelList.Add(model);
            }
            ViewBag.ListRecord = modelList;

            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Major majormodel)
        {
            if (ModelState.IsValid)
            {
                var model = new Major()
                {
                    MajorName = majormodel.MajorName,
                    IdMajor = majormodel.IdMajor,
                };

                _db.Majors.Add(model);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public bool Create(Major major)
        {
            if (ModelState.IsValid)
            {
                var model = new Major()
                {
                    MajorName = major.MajorName,
                    IdMajor = major.IdMajor,
                };

                _db.Majors.Add(model);
                _db.SaveChanges();

                return true;
            }
            return false;
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id != null)
            {

                var query = _db.Majors.SingleOrDefault(c => c.IdMajor == id);

                var model = new Major()
                {
                    IdMajor = query.IdMajor,
                    MajorName = query.MajorName
                };

                return View(model);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Update(Major major)
        {
            if (ModelState.IsValid)
            {
                var tbl = new Major()
                {
                    IdMajor = major.IdMajor,
                    MajorName = major.MajorName,
                };

                _db.Majors.Attach(tbl);
                _db.Entry(tbl).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(major);
        }

        //[HttpDelete]
        public bool Delete(int? id)
        {
            if (id != null)
            {
                var query = _db.Majors.SingleOrDefault(c => c.IdMajor == id);

                _db.Majors.Remove(query);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public PartialViewResult GetRecord(int? id)
        {
            if (id != null)
            {
                var query = _db.Majors.SingleOrDefault(c => c.IdMajor == id.Value);

                if (query != null)
                {
                    return PartialView("Edit", query);
                }
            }
            return null;
        }

        public bool EditSave(Major major)
        {
            if (ModelState.IsValid)
            {
                var tbl = new Major()
                {
                    IdMajor = major.IdMajor,
                    MajorName = major.MajorName,
                };

                _db.Majors.Attach(tbl);
                _db.Entry(tbl).State = EntityState.Modified;
                _db.SaveChanges();

                return true;
            }
            return false;
        }
    }
}