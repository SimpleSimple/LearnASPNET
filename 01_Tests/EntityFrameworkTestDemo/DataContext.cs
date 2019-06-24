using EFCodeFirst.Repository.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityframeworkTests
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("SchoolDB")
        {
        }

        public DbSet<Menu> Menus { get; set; }
    }
}
