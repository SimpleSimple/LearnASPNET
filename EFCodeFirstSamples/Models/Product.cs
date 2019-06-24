using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCodeFirstSamples.Models
{
    public class Product
    {
        public int ID { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string GoodNo { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name{ get; set; }

        
    }
}