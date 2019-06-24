using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EFCodeFirst.Repository.Model;
using EFCodeFirst.Repository.Repository;
using EFCodeFirst.Repository.Services;
namespace EFCodeFirstSamples.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService userSrv)
        {
            this.userService = userSrv;
        }

        // GET: User
        public ActionResult Index()
        {
            //userService.RemoveAll();

            //添加测试数据
            //var user = new User { Name = "sky001", Password = "sky001", PasswordSalt = "sky001", Status = 1, CreatedDate = DateTime.Parse("2009/01/01"), ModifiedDate = DateTime.Parse("2009/01/01") };
            //userService.AddUser(user);
            //var user2 = new User { Name = "sky002", Password = "sky002", PasswordSalt = "sky002", Status = 0, CreatedDate = DateTime.Parse("2009/04/01"), ModifiedDate = DateTime.Parse("2009/04/01") };
            //userService.AddUser(user);

            var list = userService.GetUsers();
            return View(list);
        }

        public ActionResult List()
        {
            var list = userService.GetUsers();
            return Json(list);
        }
    }
}