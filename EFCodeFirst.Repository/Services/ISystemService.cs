using EFCodeFirst.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Repository.Services
{
    public interface ISystemService
    {
        IList<Menu> GetAll();
        IList<Menu> GetMenus(out int totalPages, out int totalRecords, int parentId = 0);
        IList<Menu> GetMenus(out int totalPages, out int totalRecords, string where);
        IList<Menu> GetSubMenus(int parentId);
        Boolean Save(Menu menu);
        int Delete(int id);
    }
}
