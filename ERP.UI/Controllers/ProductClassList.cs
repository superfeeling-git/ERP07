using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Model;
using ERP.IBLL;
using System.Text;

namespace ERP.UI.Controllers
{
    public class ProductClassListController : Controller
    {
        private IProductClassBLL<ProductClassModel> productClassBLL;
        public ProductClassListController(IProductClassBLL<ProductClassModel> _productClassBLL)
        {
            this.productClassBLL = _productClassBLL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(int ClassID = 0, bool disabled = false)
        {            
            IList<ProductClassModel> productClasses = productClassBLL.GetAll();

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (var item in productClasses)
            {
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < item.Depth * 10; i++)
                {
                    stringBuilder.Append("&nbsp;");
                }

                stringBuilder.Append(item.ClassName);

                var listItem = new SelectListItem { Text = Server.HtmlDecode(stringBuilder.ToString()), Value = item.ClassID.ToString() };

                if(ClassID == item.ClassID)
                {
                    listItem.Selected = true;
                }

                selectListItems.Add(listItem);
            }

            ViewBag.proclass = selectListItems;

            ViewBag.disabled = disabled;

            return View();
        }
    }
}