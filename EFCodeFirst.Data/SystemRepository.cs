using EFCodeFirst.Repository.Model;
using EFCodeFirst.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Data
{
    public class SystemRepository : ISystemRepository
    {
        private readonly DataContext context = new DataContext();

        public IList<Menu> GetAll()
        {
            var list = context.Menus.ToList();
            return list;
        }
        public IList<Menu> GetMenus(out int totalPages, out int totalRecords, int parentId = 0)
        {
            totalPages = 0;
            totalRecords = 0;
            IList<Menu> list = null;
            if (parentId > 0)
            {
                list = context.Menus.Where(m => m.ParentId == parentId).AsNoTracking().ToList();
            }
            else
            {
                list = context.Menus.Where(m => m.ParentId == 0).AsNoTracking().ToList();
            }
            return list;
        }

        public IList<Menu> GetMenus(out int totalPages, out int totalRecords, string where)
        {
            totalPages = 0;
            totalRecords = 0;
            return null;
        }
        public IList<Menu> GetSubMenus(int parentId)
        {
            var list = context.Menus.Where(a => a.ParentId == parentId).ToList();
            context.Dispose();            
            return list;
        }
        public Boolean Save(Menu menu)
        {
            Menu model = null;
            if (menu.MenuId > 0)
            {
                var menuToSave = context.Menus.Where(a => a.MenuId == menu.MenuId).FirstOrDefault<Menu>();
                menuToSave.MenuName = menu.MenuName;
                menuToSave.Url = menu.Url;
                menuToSave.ParentId = menu.ParentId;
                menuToSave.Status = menu.Status;
                menuToSave.IsLeaf = menu.IsLeaf;
                context.Set<Menu>().Attach(menuToSave);
                context.Entry<Menu>(menuToSave).State = EntityState.Modified;
            }
            else
            {
                model = context.Menus.Add(menu);
                if (model == null)
                {
                    return false;
                }
            }
            int result = context.SaveChanges();
            if (result <= 0)
            {
                return false;
            }
            return true;
        }

        public int Delete(int id)
        {
            Menu menuToDel = context.Menus.Where(m => m.MenuId == id).SingleOrDefault();
            context.Menus.Remove(menuToDel);
            int result = context.SaveChanges();
            return result;
        }

        public void Dispose() {
            context.Dispose();
        }
    }
}
