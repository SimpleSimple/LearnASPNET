using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCodeFirstSamples.Models
{
    public class DataTableParameters
    {
        public int Draw { get; set; }

        public List<DataTableColumn> Data { get; set; }
    }

    public class DataTableColumn
    {
        public object Data { get; set; }
        public string Name { get; set; }
        //public bool Orderable { get; set; }
        //public bool Searchable { get; set; }
        //public Search Search { get; set; }

    }
}