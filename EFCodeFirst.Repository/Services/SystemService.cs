using EFCodeFirst.Repository.Model;
using EFCodeFirst.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Repository.Services
{
    public class SystemService : ISystemService
    {
        private ISystemRepository repository;

        public SystemService(ISystemRepository repository)
        {
            this.repository = repository;
        }

        public IList<Menu> GetAll()
        {
            return repository.GetAll();
        }

        public IList<Menu> GetMenus(out int totalPages, out int totalRecords, int parentId = 0)
        {
            return repository.GetMenus(out totalPages, out totalRecords, parentId);
        }

        public IList<Menu> GetMenus(out int totalPages, out int totalRecords, string where)
        {
            return repository.GetMenus(out totalPages, out totalRecords, where);
        }

        public IList<Menu> GetSubMenus(int parentId)
        {
            if (parentId <= 0) {
                return new List<Menu>();
            }
            IList<Menu> list = repository.GetSubMenus(parentId);
            return list;
        }

        public Boolean Save(Menu menu)
        {
            return repository.Save(menu);
        }
        public int Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
