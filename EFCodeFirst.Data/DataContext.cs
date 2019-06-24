using EFCodeFirst.Repository.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("SchoolDB")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove();

            //用户与角色多对多关系
            modelBuilder.Entity<User>()
                .HasMany(r => r.Roles)
                .WithMany(u => u.Users)
                .Map(ur =>
                {
                    ur.MapLeftKey("UserId");
                    ur.MapRightKey("RoleId");
                    ur.ToTable("UserRoles");
                });

            modelBuilder.Entity<Role>()
                .HasMany(m => m.Menus)
                .WithMany(r => r.Roles)
                .Map(ur =>
                {
                    ur.MapLeftKey("RoleId");
                    ur.MapRightKey("MenuId");
                    ur.ToTable("RoleMenus");
                });


            //modelBuilder.Entity<Role>()
            //    .HasMany(r => r.UserRoles)
            //    .WithRequired()
            //    .HasForeignKey(ur => ur.RoleId);

            //modelBuilder.Entity<User_Role>().ToTable("UserRoles")
            //    .HasKey(ur => new { ur.UserId, ur.RoleId });

            //modelBuilder.Entity<Role_Menu>().ToTable("RoleMenus")
            //    .HasKey(rm => new { rm.RoleId, rm.MenuId });
            //modelBuilder.Entity<Menu>()
            //    .HasMany(m => m.RoleMenus)
            //    .WithRequired()
            //    .HasForeignKey(rm => rm.MenuId);

        }
    }
}
