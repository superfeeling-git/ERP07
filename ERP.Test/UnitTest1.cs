using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ERP.UI.Controllers;
using ERP.Common;
using System.Data;

namespace ERP.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("abc".MD5Encrypt());
        }
    }
}
