using EFCodeFirst.Repository.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityframeworkTests
{
    class Program
    {
        private static DataContext context = new DataContext();

        static void Main(string[] args)
        {
            // 清除所有数据
            var menus = context.Menus.ToList();
            foreach (var menu in menus)
            {
                context.Menus.Remove(menu);
                //context.SaveChanges();
            }
            Console.WriteLine("菜单数据已删除！");


            //显示菜单所有数据
            //DisplayAll();

            ////更新数据
            //var menu = new Menu { MenuId = 4, MenuName = "组织列表", Url = "/Organization/Index", ParentId = 2, Status = 1, IsLeaf = 0 };
            //try
            //{
            //    //context.Entry(menu).State = EntityState.Modified;
            //    context.Set<Menu>().Attach(menu);
            //    context.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    Console.Write(ex.Message);
            //}
            //Console.WriteLine();
            //DisplayAll();

            // 添加菜单
            Program p = new Program();
            p.add();
            Console.WriteLine("Add completed！");

            p.displayAll();

            p.update();
            Console.WriteLine("Update completed！");

            // 查询所有菜单
            p.displayAll();

            Console.Read();
        }

        // add
        public void add()
        {
            var menu_1 = new Menu { MenuNo = 0, MenuName = "角色管理", Url = "", ParentId = 0, Status = 1 };
            var menu_11 = new Menu { MenuNo = 0, MenuName = "角色列表", Url = "/Role/Index", ParentId = 0, Status = 1 };

            var menu_2 = new Menu { MenuNo = 0, MenuName = "组织管理", Url = "", ParentId = 0, Status = 1 };
            var menu_21 = new Menu { MenuNo = 0, MenuName = "组织列表", Url = "/Organized/Index", ParentId = 0, Status = 1 };

            var menu_3 = new Menu { MenuNo = 0, MenuName = "菜单管理", Url = "", ParentId = 0, Status = 1 };
            var menu_31 = new Menu { MenuNo = 0, MenuName = "菜单列表", Url = "/Menu/Index", ParentId = 0, Status = 1 };

            var menu_4 = new Menu { MenuNo = 0, MenuName = "用户管理", Url = "", ParentId = 0, Status = 1 };
            var menu_41 = new Menu { MenuNo = 0, MenuName = "用户列表", Url = "/User/Index", ParentId = 0, Status = 1 };
            var menu_42 = new Menu { MenuNo = 0, MenuName = "用户测试列表", Url = "/User/Testlist", ParentId = 0, Status = 1 };

            //using (var ctx = new DataContext())
            //{
            context.Menus.Add(menu_1);
            context.Menus.Add(menu_11);
            context.Menus.Add(menu_2);
            context.Menus.Add(menu_21);
            context.Menus.Add(menu_3);
            context.Menus.Add(menu_31);
            context.Menus.Add(menu_4);
            context.Menus.Add(menu_41);

            context.SaveChanges();
            //}
        }

        public void update()
        {
            var menu = context.Menus.Single(x => x.MenuName == "角色管理");
            if (menu != null)
            {
                menu.MenuName = "修改菜单1";

                context.SaveChanges();
            }
        }

        void displayAll()
        {
            var list = context.Menus.ToList();
            //list.ForEach(a => Console.WriteLine($"MenuName= {a.MenuName} ,Url= {a.Url}"));
            foreach (var item in list)
            {
                Console.WriteLine($"MenuName= {item.MenuName} ,Url= {item.Url}");
            }
        }
    }
}
