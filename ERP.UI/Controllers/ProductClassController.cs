using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.IBLL;
using ERP.Model;

namespace ERP.UI.Controllers
{
    public class ProductClassController : Controller
    {
        private IProductClassBLL<ProductClassModel> productClassBLL;

        private IList<ProductClassModel> proclass = new List<ProductClassModel>();

        public ProductClassController(IProductClassBLL<ProductClassModel> _productClassBLL)
        {
            productClassBLL = _productClassBLL;
            proclass = productClassBLL.GetAll();
        }

        // GET: ProductClass
        public ActionResult Index()
        {
            return View(proclass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(productClassBLL.GetModelByID(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(ProductClassModel productClassModel)
        {
            return Json(productClassBLL.Update(productClassModel), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(ProductClassModel productClassModel)
        {
            return new JsonResult { Data = productClassBLL.Create(productClassModel), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var returnInfo = productClassBLL.Delete(id);
            return Json(returnInfo, JsonRequestBehavior.AllowGet);
        }

        List<TreeModel> treeModels = new List<TreeModel>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TreeData()
        {
            foreach (var item in proclass.Where(m => m.ParentID == 0))
            {
                TreeModel model = new TreeModel { title = item.ClassName, id = item.ClassID };

                SubNodeData(model);

                treeModels.Add(model);
            }

            return Json(treeModels, JsonRequestBehavior.AllowGet);
        }

        public void SubNodeData(TreeModel model)
        {
            foreach (var item in proclass.Where(m => m.ParentID == model.id))
            {
                TreeModel subNode = new TreeModel { id = item.ClassID, title = item.ClassName };

                model.children.Add(subNode);

                SubNodeData(subNode);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MoveClass(int id)
        {
            return View(productClassBLL.GetModelByID(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MoveClass(int ClassID, int TargetId)
        {
            return Json(productClassBLL.MoveClass(ClassID, TargetId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Test()
        {
            return View();
        }
    }
}