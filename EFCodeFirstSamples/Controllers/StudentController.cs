using EFCodeFirstSamples.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstSamples.Controllers
{
    public class StudentController : Controller
    {
        SchoolContext db = new SchoolContext();


        // GET: Student
        public ActionResult Index()
        {            
            //foreach (var s in assemblys)
            //{
            //    LogHelper.Log(LogLevel.Info, s.GetName().Name);
            //}
            var list = db.Students.ToList();
            return View(list);
        }
    }
}