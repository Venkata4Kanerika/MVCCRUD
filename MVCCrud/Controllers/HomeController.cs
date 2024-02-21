using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrud.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}


        SimpliMVCDBEntities _context = new SimpliMVCDBEntities();
        //SimpliMVCDBContext _context = new SimpliMVCDBContext();
        public ActionResult Index()
        {
            var listofData = _context.Students.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student model)
        {
            _context.Students.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }

        [HttpGet]

        public ActionResult Edit(int id)

        {

            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();

            return View(data);

        }

        [HttpPost]

        public ActionResult Edit(Student Model)

        {

            var data = _context.Students.Where(x => x.StudentId == Model.StudentId).FirstOrDefault();

            if (data != null)

            {

                data.StudentName = Model.StudentName;

                data.StudentFees = Model.StudentFees;

                data.StudentCity = Model.StudentCity;

                _context.SaveChanges();

            }

            return RedirectToAction("index");

        }

        public ActionResult Detail(int id)

        {

            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();

            return View(data);

        }

        public ActionResult Delete(int id)

        {

            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();

            _context.Students.Remove(data);

            _context.SaveChanges();

            ViewBag.Messsage = "Record Delete Successfully";

            return RedirectToAction("index");

        }

    }
}