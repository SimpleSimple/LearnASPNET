using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EFCodeFirst.Repository.Model;
namespace EFCodeFirstSamples.Models
{
    public class JqGridData
    {
        public int page { get; set; }

        public int total { get; set; }

        public int records { get; set; }

        public IList<Menu> rows { get; set; }
    }
}