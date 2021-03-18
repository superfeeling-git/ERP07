using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;

namespace ERP.UI.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();

            ISheet sheet = hssfworkbook.CreateSheet("test");

            using (FileStream file = new FileStream(Server.MapPath("/test.xls"), FileMode.Create))
            {
                hssfworkbook.Write(file);
                file.Close();
            }

            return new EmptyResult();
        }
    }
}