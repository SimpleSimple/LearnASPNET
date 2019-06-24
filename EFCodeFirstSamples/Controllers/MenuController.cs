using EFCodeFirst.Repository.Model;
using EFCodeFirst.Repository.Repository;
using EFCodeFirst.Repository.Services;
using EFCodeFirstSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstSamples.Controllers
{
    public class MenuController : BaseController
    {
        private readonly ISystemService systemService = null;

        public MenuController(ISystemService service)
        {
            this.systemService = service;
        }

        // GET: Menu
        public ActionResult Index()
        {
            //ViewBag.ColumnNames = new string[] { "菜单ID", "菜单编号", "菜单名称", "菜单路径", "状态", "父路径" };
            return View();
        }
        public ActionResult TestData()
        {
            var list = new List<Menu>();
            list.Add(new Menu { MenuId = 1, MenuNo = 1, MenuName = "菜单管理", Url = "", ParentId = 0, Status = 1 });
            list.Add(new Menu { MenuId = 2, MenuNo = 2, MenuName = "菜单列表", Url = "/Menu/Index", ParentId = 1, Status = 1 });
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            return Content(
                jss.Serialize(new JqGridData
                {
                    page = 1,
                    total = 1,
                    records = list.Count,
                    rows = list
                }));
        }

        ///用于jqGrid获取菜单列表数据
        [HttpGet]
        public ActionResult List()
        {
            int totals = 0;
            int records = 0;
            var list = systemService.GetAll();
            IList<Menu> newList = new List<Menu>();

            foreach (var item in list)
            {                
                if (item.ParentId == 0)
                {
                    newList.Add(item);
                    var subList = systemService.GetSubMenus(item.MenuId);
                    foreach (var subItem in subList)
                    {
                        subItem.MenuName = "——" + subItem.MenuName;
                        newList.Add(subItem);
                    }
                }
            }
            return Json(new JqGridData { page = 0, total = totals, records = records, rows = newList });
        }

        [HttpPost]
        public ActionResult Save(Menu menu)
        {
            if (menu != null && menu.MenuId > 0)
            {
                String msg = String.Format("Menu Object：ID={0} Name={1} Url={2} Status={3} IsLeaf={4}",
                    menu.MenuId, menu.MenuName, menu.Url, menu.Status, menu.IsLeaf);
                LogHelper.Log(LogLevel.Error, msg);
                bool flag = systemService.Save(menu);
                if (flag) return Success(null, "处理成功", 1);
                else return Error(null, "处理失败");
            }
            else
            {
                string act = Request["oper"];
                Int32 id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                Int32 result = 0;
                if (act == "del")
                    result = systemService.Delete(id);

                if (result > 0) return Success(null, "删除成功");
                else return Error(null, "删除失败");
            }
        }

        public ActionResult JSONData()
        {
            String strJSON2 = "{\"page\":\"2\"," +
                "      \"total\":2," +
                "      \"records\":\"13\"," +
                "      \"rows\":" +
                "          [" +
                "            {" +
                "              \"id\":\"13\"," +
                "              \"cell\":" +
                "                  [\"13\",\"2007-10-06\",\"Client 3\",\"1000.00\",\"0.00\",\"1000.00\",null]" +
                "            }," +
                "            {" +
                "              \"id\":\"12\"," +
                "              \"cell\":" +
                "                  [\"12\",\"2007-10-06\",\"Client 2\",\"700.00\",\"140.00\",\"840.00\",null]" +
                "            }," +
                "            {" +
                "              \"id\":\"11\"," +
                "              \"cell\":" +
                "                  [\"11\",\"2007-10-06\",\"Client 1\",\"600.00\",\"120.00\",\"720.00\",null]" +
                "            }," +
                "            {" +
                "              \"id\":\"10\"," +
                "              \"cell\":" +
                "                  [\"10\",\"2007-10-06\",\"Client 2\",\"100.00\",\"20.00\",\"120.00\",null]" +
                "            }," +
                "            {" +
                "              \"id\":\"9\"," +
                "              \"cell\":" +
                "                  [\"9\",\"2007-10-06\",\"Client 1\",\"200.00\",\"40.00\",\"240.00\",null]" +
                "            }," +
                "            {" +
                "              \"id\":\"8\"," +
                "              \"cell\":" +
                "                  [\"8\",\"2007-10-06\",\"Client 3\",\"200.00\",\"0.00\",\"200.00\",null]" +
                "            }," +
                "            {" +
                "              \"id\":\"7\"," +
                "              \"cell\":" +
                "                  [\"7\",\"2007-10-05\",\"Client 2\",\"120.00\",\"12.00\",\"134.00\",null]" +
                "            }," +
                "            {" +
                "              \"id\":\"6\"," +
                "              \"cell\":" +
                "                  [\"6\",\"2007-10-05\",\"Client 1\",\"50.00\",\"10.00\",\"60.00\",\"\"]" +
                "            }," +
                "            {" +
                "              \"id\":\"5\"," +
                "              \"cell\":" +
                "                  [\"5\",\"2007-10-05\",\"Client 3\",\"100.00\",\"0.00\",\"100.00\",\"no tax at all\"]" +
                "            }," +
                "            {" +
                "              \"id\":\"4\"," +
                "              \"cell\":" +
                "                  [\"4\",\"2007-10-04\",\"Client 3\",\"150.00\",\"0.00\",\"150.00\",\"no tax\"]" +
                "            }" +
                "          ]," +
                "      \"userdata\":{\"amount\":3220,\"tax\":342,\"total\":3564,\"name\":\"Totals:\"}" +
                "    }";
            return Content(strJSON2);
        }

        public ActionResult ShowLeftMenu()
        {
            //IList<Menu> list = new List<Menu>();
            //list.Add(new Menu { MenuName = "测试菜单1", MenuNo = 1, Url = "", ParentId = 0, Status = 1 });
            //list.Add(new Menu { MenuName = "测试子菜单1-1", MenuNo = 3, Url = "/Test/Index", ParentId = 1, Status = 1 });
            //list.Add(new Menu { MenuName = "测试菜单2", MenuNo = 2, Url = "", ParentId = 0, Status = 1 });
            //list.Add(new Menu { MenuName = "测试子菜单2", MenuNo = 4, Url = "/Test/Index2", ParentId = 2, Status = 1 });
            //list.Add(new Menu { MenuName = "测试子菜单1-2", MenuNo = 5, Url = "/Test/Index1-2", ParentId = 1, Status = 1 });

            var list = systemService.GetAll();

            var newList = new List<Menu>();
            foreach (var item in list)
            {
                if (item.ParentId == 0)
                {
                    item.SubMenus = GetSubMenus(item.MenuNo, list);
                    newList.Add(item);
                }
            }
            return PartialView("_LeftMenu", newList);
        }

        //public IList<Menu> GetSubMenus(int pId)
        //{
        //    return systemService.GetSubMenus(pId);
        //}
        public List<Menu> GetSubMenus(int pId, IList<Menu> dataSource)
        {
            var newList = new List<Menu>();
            foreach (var item in dataSource)
            {
                if (item.ParentId == pId &&
                    item.ParentId > 0)
                {
                    newList.Add(item);
                }
            }
            return newList;
        }
    }
}