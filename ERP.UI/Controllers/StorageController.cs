using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Common;
using ERP.IBLL;
using ERP.Model;

namespace ERP.UI.Controllers
{
    [Authorize]
    public class StorageController : Controller
    {
        private IStorageTypeBLL<StorageTypeModel> storageTypeBLL;

        private IStorageBLL<StorageModel> storageBLL;

        private IDictBLL<DictModel> dictBLL;

        public StorageController(
            IStorageTypeBLL<StorageTypeModel> _storageTypeBLL, 
            IStorageBLL<StorageModel> _storageBLL,
            IDictBLL<DictModel> _dictBLL
            )
        {
            this.storageTypeBLL = _storageTypeBLL;
            this.storageBLL = _storageBLL;
            this.dictBLL = _dictBLL;
        }

        // GET: Storage
        public ActionResult Index(StorageModel searchModel, string field, string order, int pageIndex = 1,int pageSize = 10)
        {
            if(Request.IsAjaxRequest())
            {
                var data = storageBLL.GetPage<StorageModel>(field, order, searchModel, pageIndex, pageSize);
                return Json(new
                {
                    status = 0,
                    total = data.Item2,
                    data = data.Item1
                },
                JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            SelectList typeLists = new SelectList(storageTypeBLL.GetAll(), "StorageTypeID", "StorageTypeName");
            ViewData["typeLists"] = typeLists;

            ViewData["dictLists"] = dictBLL.GetAll().Where(m => m.DictType == 4);
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(StorageModel storageModel)
        {
            return Json(storageBLL.Create(storageModel), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SelectList typeLists = new SelectList(storageTypeBLL.GetAll(), "StorageTypeID", "StorageTypeName");
            ViewData["typeLists"] = typeLists;

            ViewData["dictLists"] = dictBLL.GetAll().Where(m => m.DictType == 4);

            return View(storageBLL.GetModelByID(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(StorageModel storageModel)
        {
            return Json(storageBLL.Update(storageModel), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int[] StorageID)
        {
            return Json(storageBLL.BatchDelete(StorageID), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateStatus(int StorageID)
        {
            return Json(storageBLL.UpdateStatus(StorageID),JsonRequestBehavior.AllowGet);
        }
    }
}