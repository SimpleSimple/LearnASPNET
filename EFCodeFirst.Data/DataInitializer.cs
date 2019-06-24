using EFCodeFirst.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Data
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext db)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(DataInitializer));
            log.Debug("11111111111111111111");
            //var user = new User { Name = "sky001", Password = "sky001", PasswordSalt = "sky001", Status = 1, CreatedDate = DateTime.Parse("2009/01/01"), ModifiedDate = DateTime.Parse("2009/01/01") };
            //userService.AddUser(user);
            //var user2 = new User { Name = "sky002", Password = "sky002", PasswordSalt = "sky002", Status = 0, CreatedDate = DateTime.Parse("2009/04/01"), ModifiedDate = DateTime.Parse("2009/04/01") };
            //userService.AddUser(user);

            //db.Database.ExecuteSqlCommand("DELETE FROM dbo.Users");
            var users = new List<User>
            {
                new User{Name="zhangsan",Password="zhangsan!23",Status=1,CreatedDate=DateTime.Parse("2007/01/01"), ModifiedDate = DateTime.Parse("2007/03/01")},
                new User{Name="zhaosi",Password="zhaosi123",Status=1,CreatedDate=DateTime.Parse("2008/03/01"), ModifiedDate = DateTime.Parse("2008/12/01")},
                new User{Name="zhangfei",Password="zhangfei123",Status=0,CreatedDate=DateTime.Parse("2009/01/01"), ModifiedDate = DateTime.Parse("2009/03/01")},
                new User{Name="sky001",Password="123456",Status=0,CreatedDate=DateTime.Parse("2009/01/01"), ModifiedDate = DateTime.Parse("2009/03/01")},
                new User{Name="sky002",Password="123456",Status=0,CreatedDate=DateTime.Parse("2009/01/01"), ModifiedDate = DateTime.Parse("2009/03/01")},
                new User{Name="sky003",Password="123456",Status=1,CreatedDate=DateTime.Parse("2010/01/01"), ModifiedDate = DateTime.Parse("2010/07/01")},
                new User{Name="sky004",Password="123456",Status=0,CreatedDate=DateTime.Parse("2010/01/01"), ModifiedDate = DateTime.Parse("2010/09/01")},
                new User{Name="sky005",Password="123456",Status=1,CreatedDate=DateTime.Parse("2010/01/01"), ModifiedDate = DateTime.Parse("2010/09/01")},
                new User{Name="sky006",Password="123456",Status=1,CreatedDate=DateTime.Parse("2010/01/01"), ModifiedDate = DateTime.Parse("2010/07/01")},
                new User{Name="sky007",Password="123456",Status=1,CreatedDate=DateTime.Parse("2011/01/01"), ModifiedDate = DateTime.Parse("2011/11/01")},
            };
            users.ForEach(u => db.Users.Add(u));
            db.SaveChanges();

            var roles = new List<Role> { };
            roles.Add(new Role { RoleName = "系统管理员" });
            roles.Add(new Role { RoleName = "用户管理" });
            roles.ForEach(r => db.Roles.Add(r));
            db.SaveChanges();

            var menus = new List<Menu>();
            menus.Add(new Menu { MenuName = "菜单管理", MenuNo = 01, Url = "", ParentId = 0, Status = 1, IsLeaf = 1 });
            menus.Add(new Menu { MenuName = "菜单列表", MenuNo = 02, Url = "/Menu/Index", ParentId = 01, Status = 1, IsLeaf = 1 });
            menus.Add(new Menu { MenuName = "用户管理", MenuNo = 03, Url = "", ParentId = 0, Status = 1, IsLeaf = 1 });
            menus.Add(new Menu { MenuName = "用户列表", MenuNo = 04, Url = "/User/Index", ParentId = 03, Status = 1, IsLeaf = 1 });
            menus.ForEach(m => db.Menus.Add(m));
            db.SaveChanges();

            //var roleMenus = new List<Role_Menu>();
            //roleMenus.Add(new Role_Menu { RoleId});
        }
    }
}
