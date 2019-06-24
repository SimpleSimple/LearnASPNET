using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCodeFirst.Repository.Model
{
    public class Role
    {
        public Role()
        {
            this.Users = new List<User>();
            this.Menus = new HashSet<Menu>();
        }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
