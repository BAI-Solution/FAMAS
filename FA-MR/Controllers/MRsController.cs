using FA_MR.Models;
using FA_MR.Models.Interface;
using Library.BLO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA_MR.Controllers
{
    public class MRsController : BaseController
    {
        #region BLO
        IMRs lIMRs;
        #endregion
        #region Models
        IMMRs lIMMRs;
        IMAssetsItems lIMAssetsItems;
        #endregion
        #region Construct
        public MRsController(IMRs pIMRs, IMMRs pIMMRs, IMAssetsItems pIMAssetsItems)
        {
            lIMRs = pIMRs;
            lIMMRs = pIMMRs;
            lIMAssetsItems = pIMAssetsItems;
        }
        #endregion
        #region Method
        [HttpGet]
        public JsonResult GetMRsAssetsItems()
        {
            try
            {
                var _mr = lIMAssetsItems.ToModel(lIMRs.Get());

                return Json(new
                {
                    success = true,
                    data = _mr
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
        public JsonResult GetAssetMovement(long pAIID)
        {
            try
            {
                var _mr = lIMMRs.ToModel(lIMRs.Get(pAIID, "AssetItemId"));

                return Json(new
                {
                    success = true,
                    data = _mr
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
        public JsonResult InsertMR(IList<MMRs> pObj)
        {
            try
            {
                var _bind = lIMMRs.ToBinding(pObj);
                string _log = UserLog.MAIL;
                lIMRs.Insert(_bind, _log, UserLog.EMID);

                return Json(new
                {
                    success = true,
                    message = "MR successfully saved"
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
        public JsonResult Surrender(IList<MMRs> pObj)
        {
            try
            {
                var _bind = lIMMRs.ToBinding(pObj);
                string _log = UserLog.MAIL;
                lIMRs.Update(_bind, _log);

                return Json(new
                {
                    success = true,
                    message = "MR successfully created"
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