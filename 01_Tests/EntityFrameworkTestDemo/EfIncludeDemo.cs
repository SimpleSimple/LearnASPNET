using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityframeworkTests
{
    public class EfIncludeDemo
    {
        private DataContext db = new DataContext();

        internal void IncludeTest()
        {
            var query = db.Set<EFCodeFirst.Repository.Model.TableA>().Include(x => x.TableBList);
            foreach (var item in query.ToList())
            {
                Console.WriteLine(item.ID);
            }
        }


        // A -> Roles -> Menu_ID（1,3,5）
        // B -> Menus


    }
}
