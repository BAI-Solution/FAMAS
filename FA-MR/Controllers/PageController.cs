using FA_MR.Models.Interface;
using Library.BLO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA_MR.Controllers
{
    public class PageController : BaseController
    {
        #region BLO
        IAssetsTypes lIAssetsTypes;
        IAssetsGroups lIAssetsGroups;
        IAssetsItems lIAssetsItems;
        IBusinessUnits lIBusinessUnits;
        IDepartments lIDepartments;
        IEmployees lIEmployees;
        IPositions lIPositions;
        #endregion
        #region Models
        IMAssetsItems lIMAssetsItems;
        IMAuditsTrails lIMAuditsTrails;
        IMEmployees lIMEmployees;
        IMMRs lIMMRs;
        #endregion
        #region Construct
        public PageController(IAssetsTypes pIAssetsTypes, IAssetsGroups pIAssetsGroups, IAssetsItems pIAssetsItems, IBusinessUnits pIBusinessUnits, IDepartments pIDepartments, IEmployees pIEmployees, IPositions pIPositions, IMAssetsItems pIMAssetsItems, IMAuditsTrails pIMAuditsTrails, IMEmployees pIMEmployees, IMMRs pIMMRs)
        {
            #region BLO
            lIAssetsTypes = pIAssetsTypes;
            lIAssetsGroups = pIAssetsGroups;
            lIAssetsItems = pIAssetsItems;
            lIBusinessUnits = pIBusinessUnits;
            lIDepartments = pIDepartments;
            lIEmployees = pIEmployees;
            lIPositions = pIPositions;
            #endregion
            #region Models
            lIMAssetsItems = pIMAssetsItems;
            lIMAuditsTrails = pIMAuditsTrails;
            lIMEmployees = pIMEmployees;
            lIMMRs = pIMMRs;
            #endregion
        }
        #endregion
        #region Method
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}