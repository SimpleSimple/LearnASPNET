using EFCodeFirst.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Repository.Repository
{
    public interface ISystemRepository
    {
        IList<Menu> GetMenus(out int totalPages, out int totalRecords, int parentId = 0);
        IList<Menu> GetMenus(out int totalPages, out int totalRecords, string where);
        IList<Menu> GetAll();
        IList<Menu> GetSubMenus(int parentId);
        Boolean Save(Menu menu);
        int Delete(int id);

        void Dispose();
    }
}
