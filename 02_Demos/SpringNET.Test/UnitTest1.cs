using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NUnit.Framework;
using NHibernate_AspNetMvc.Service;
using Spring.Context;
using Spring.Context.Support;
namespace SpringNET.Test
{
    [TestClass]
    public partial class TransactionTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            IUserService service = (IUserService)ctx.GetObject("userService");
            service.SaveData("刘冬", 26, "1233456");
        }
    }
}
