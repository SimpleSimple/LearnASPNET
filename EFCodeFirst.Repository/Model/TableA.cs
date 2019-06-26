using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Repository.Model
{
    public class TableA : BaseEntity<long>
    {
        public string Name { get; set; }

        public string B_ID { get; set; }

        public virtual List<TableB> TableBList { get; set; }
    }
}
