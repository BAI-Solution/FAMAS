using FA_MR.Models.Interface;
using Library.BLO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA_MR.Controllers
{
    public class EmployeesController : Controller
    {
        #region BLO
        IEmployees lIEmployees;
        IBusinessUnits lIBusinessUnits;
        IDepartments lIDepartments;
        IPositions lIPositions;
        #endregion
        #region Models
        IMEmployees lIMEmployees;
        #endregion
        #region Construct
        public EmployeesController(IEmployees pIEmployees, IBusinessUnits pIBusinessUnits, IDepartments pIDepartments, IPositions pIPositions, IMEmployees pIMEmployees)
        {
            lIEmployees = pIEmployees;
            lIBusinessUnits = pIBusinessUnits;
            lIDepartments = pIDepartments;
            lIPositions = pIPositions;
            lIMEmployees = pIMEmployees;
        }
        #endregion
        #region Method
        [HttpGet]
        public JsonResult GetEmployeeRepo()
        {
            try
            {
                var _bu = lIMEmployees.ToModel(lIBusinessUnits.Get());
                var _de = lIMEmployees.ToModel(lIDepartments.Get());
                var _po = lIMEmployees.ToModel(lIPositions.Get());

                return Json(new
                {
                    success = true,
                    data = new { BUNT = _bu, DPRT = _de, PSTN = _po }
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
        public JsonResult GetEmployeeInfo(string pBUNT, string pDPRT)
        {
            try
            {
                var _em = lIMEmployees.ToModel(lIEmployees.Get(pDPRT, pBUNT));
                return Json(new
                {
                    success = true,
                    data = _em
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