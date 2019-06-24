using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EFCodeFirst.Repository.Model;
using EFCodeFirst.Repository.Services;
namespace EFCodeFirstSamples.Controllers
{
    public class BaseController : Controller
    {      

        // GET: Base
        protected new JsonResult Json(object data)
        {
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult Success(object data = null, string msg = "", int code = 0)
        {
            return Json(new Result { Code = code, Data = data, Msg = msg },
                JsonRequestBehavior.AllowGet);
        }
        protected JsonResult Error(object data = null, string msg = "", int code = -1)
        {
            return Json(new Result { Code = code, Data = data, Msg = msg },
                JsonRequestBehavior.AllowGet);
        }

        protected void RemoveAll(string table)
        {

        }
    }

    public class Result
    {
        public Int32 Code { get; set; }
        public Object Data { get; set; }
        public String Msg { get; set; }
    }
}