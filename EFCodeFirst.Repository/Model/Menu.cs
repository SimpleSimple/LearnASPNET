using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Repository.Model
{
    public class Menu
    {
        public Menu()
        {
            this.Roles = new HashSet<Role>();
            this.SubMenus = new List<Menu>();
        }
        /// <summary>
        /// 表主键
        /// </summary>
        public int MenuId { get; set; }
        /// <summary>
        /// 菜单编号
        /// </summary>
        public Int32 MenuNo { get; set; }
        public string MenuName { get; set; }
        //菜单路径
        public string Url { get; set; }
        //父路径
        public Int32 ParentId { get; set; }
        /// <summary>
        /// 状态（1-启用 0-未启用）
        /// </summary>
        public Byte Status { get; set; }
        /// <summary>
        /// 是否叶节点(1-是 0-否）
        /// </summary>
        public Byte IsLeaf { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Menu> SubMenus { get; set; }
    }
}
