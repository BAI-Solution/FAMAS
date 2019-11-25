using FA_MR.Models;
using FA_MR.Models.Interface;
using GlobalObject;
using Library.BLO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA_MR.Controllers
{
    public class FixedAssetsController : BaseController
    {
        #region BLO
        IAssetsItems lIAssetsItems;
        IAssetsGroups lIAssetsGroups;
        IAssetsTypes lIAssetsTypes;
        IUOMs lIUOMs;
        #endregion
        #region Models
        IMAssetsItems lIMAssetsItems;
        #endregion
        #region Construct
        public FixedAssetsController(IAssetsItems pIAssetsItems, IAssetsGroups pIAssetsGroups, IAssetsTypes pIAssetsTypes, IUOMs pIUOMs, IMAssetsItems pIMAssetsItems)
        {
            lIAssetsItems = pIAssetsItems;
            lIAssetsGroups = pIAssetsGroups;
            lIAssetsTypes = pIAssetsTypes;
            lIUOMs = pIUOMs;
            lIMAssetsItems = pIMAssetsItems;
        }
        #endregion
        #region Method
        [HttpGet]
        public JsonResult GetItems()
        {
            try
            {
                var _ai = lIMAssetsItems.ToModel(lIAssetsItems.Get());
                var _ag = lIMAssetsItems.ToModel(lIAssetsGroups.Get());
                var _at = lIMAssetsItems.ToModel(lIAssetsTypes.Get());
                var _um = lIMAssetsItems.ToModel(lIUOMs.Get()); 

                return Json(new
                {
                    success = true,
                    data = new { AITM = _ai, AGRP = _ag, ATYP = _at, UMEA = _um }
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetFiltered(string AGRP, string ATYP)
        {
            try
            {
                var _ai = lIMAssetsItems.ToModel(lIAssetsItems.Get(AGRP, ATYP));

                return Json(new
                {
                    success = true,
                    data = _ai
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message 
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetAssigned()
        {
            try
            {
                var _ai = lIMAssetsItems.ToModel(lIAssetsItems.Get(AssetStatus.Assigned.ToString()));

                return Json(new
                {
                    success = true,
                    data = _ai
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetDisposed()
        {
            try
            {
                var _ai = lIMAssetsItems.ToModel(lIAssetsItems.Get(AssetStatus.Disposed.ToString()));

                return Json(new
                {
                    success = true,
                    data = _ai
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult InsertAssetItem(MAssetsItems pObj)
        {
            try
            {
                string _log = UserLog.MAIL;
                var _asset = lIMAssetsItems.ToBinding(pObj);
                lIAssetsItems.Insert(_asset, _log);
                return Json(new
                {
                    success = true,
                    message = "Add asset successfully save"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult UpdateAssetItem(MAssetsItems pObj)
        {
            try
            {
                string _log = UserLog.MAIL;
                var _asset = lIMAssetsItems.ToBinding(pObj);
                lIAssetsItems.Update(_asset, _log);
                return Json(new
                {
                    success = true,
                    message = "Update asset successfully save"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult UpdateStatus(IList<MAssetsItems> pObj)
        {
            try
            {
                var _ai = lIMAssetsItems.ToBinding(pObj);
                string _log = UserLog.MAIL;
                lIAssetsItems.Update(_log, _ai);

                return Json(new
                {
                    success = true,
                    message = "Dispose successfully save"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}