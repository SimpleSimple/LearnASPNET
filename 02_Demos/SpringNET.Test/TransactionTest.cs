using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NUnit.Framework;
using NHibernate_AspNetMvc.Service;
using Spring.Context;
using Spring.Context.Support;

namespace SpringNET.Test
{
    [TestFixture]
    public partial class TransactionTest
    {
        [Test]
        public void AdoTransaction()
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            IUserService service = (IUserService)ctx.GetObject("userService");
            service.SaveData("刘冬", 26, "1233456");
        }
    }
}
