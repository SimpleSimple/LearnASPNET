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
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context = new DataContext();

        public UserRepository() { }

        public int AddUser(User user)
        {
            context.Users.Add(user);
            return context.SaveChanges();
        }
        public IQueryable<User> GetUsers()
        {
            return from u in context.Users
                   select u;
        }

        public IList<User> GetUsers(Byte status)
        {
            return (from u in context.Users
                    select u).ToList();
        }

        public User GetUser(string name)
        {
            return (from u in context.Users
                    where u.Name == name
                    select u).FirstOrDefault();
        }

        public User GetUser(string name, string password)
        {
            return (from u in context.Users
                    where u.Name == name && 
                        u.Password == password
                    select u).FirstOrDefault();
        }

        public void RemoveAll()
        {
            context.Database.ExecuteSqlCommand("DELETE FROM Users");
        }
    }
}
