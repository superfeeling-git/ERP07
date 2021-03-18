using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.IBLL;
using ERP.Model;
using System.IO;
using ERP.Common;
using System.Web.Security;

namespace ERP.UI.Controllers
{
    public class SupplierController : Controller
    {
        private IDictBLL<DictModel> dictBLL;
        private IProductClassBLL<ProductClassModel> productClassBLL;
        private ISupplierBLL<SupplierModel> supplierBLL;


        public SupplierController(
            IDictBLL<DictModel> _dictBLL, 
            IProductClassBLL<ProductClassModel> _productClassBLL,
            ISupplierBLL<SupplierModel> _supplierBLL
            )
        {
            this.dictBLL = _dictBLL;
            this.productClassBLL = _productClassBLL;
            this.supplierBLL = _supplierBLL;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierModel">查询条件</param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public ActionResult Index(SupplierModel supplierModel, int PageIndex = 1)
        {
            ViewBag.model = supplierModel;
            ViewBag.dict = dictBLL.GetAll();
            return View(supplierBLL.GetPage<SupplierModel>(ProperyHelper.GetKeyName<SupplierModel>(), supplierModel, PageIndex));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            if(User.Identity.IsAuthenticated)
            { 
                //MemberShip
                string username = User.Identity.Name;

                string AuthenticationType = User.Identity.AuthenticationType;

                bool isLogin = User.Identity.IsAuthenticated;

                FormsIdentity formsIdentity = (FormsIdentity)User.Identity;

                string userData = formsIdentity.Ticket.UserData;

                Response.Write(userData);
            }
            ViewBag.dict = dictBLL.GetAll();
            ViewBag.proclass = productClassBLL.GetAll();
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(SupplierModel supplierModel)
        {
            return Json(supplierBLL.Create(supplierModel), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.dict = dictBLL.GetAll();
            ViewBag.proclass = productClassBLL.GetAll();
            ViewBag.brand = supplierBLL.GetBrandBySupplierID(id);

            return View(supplierBLL.GetModelByID(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(SupplierModel supplierModel)
        {
            return Json(supplierBLL.Update(supplierModel), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int[] SupplierID)
        {
            return Json(supplierBLL.BatchDelete(SupplierID), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetBrand(int id)
        {
            return Json(productClassBLL.GetAll().Where(m => m.ParentID == id), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            ///UploadFiles/20210305/202204232394.jpg
            //根目录的图片文件夹
            string RootDir = "/UploadFiles";

            if(!Directory.Exists(Server.MapPath(RootDir)))
            {
                Directory.CreateDirectory(Server.MapPath(RootDir));
            }

            //当前月的文件夹
            string currMonth = DateTime.Now.ToString("yyyyMM");
            if (!Directory.Exists(Server.MapPath($"{RootDir}/{currMonth}")))
            {
                Directory.CreateDirectory(Server.MapPath($"{RootDir}/{currMonth}"));
            }


            string FileName = string.Empty;

            if (file.ContentLength > 0)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());

                FileName = DateTime.Now.ToString($"yyyyMMddHHmmss_ffff_{random.Next(1000, 9999)}");
                
                string FileExt = Path.GetExtension(file.FileName);

                FileName = $"{ RootDir}/{ currMonth}/{ FileName}{FileExt}";

                file.SaveAs(Server.MapPath(FileName));
            }

            return Json(new { code = 0, msg = "",data = new { src = FileName } },JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeletePhoto(string path)
        {
            try
            {
                if (System.IO.File.Exists(Server.MapPath(path)))
                    System.IO.File.Delete(Server.MapPath(path));
            }
            catch (Exception e)
            {
                string msg = e.Message;
                throw;
            }

            return Json(new { code = 1 }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateStatus(int[] SupplierID, string status)
        {
            return Json(supplierBLL.UpdateStatus(SupplierID, status), JsonRequestBehavior.AllowGet);
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