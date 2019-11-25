using FA_MRService.Models;
using FA_MRService.Models.Interface;
using Library.BLO;
using Library.BLO.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace FA_MRService.Controllers
{
    public class ReportController : ApiController
    {
        #region BLO
        IReports lIReports;
        #endregion
        #region Model
        IMAssetsItems lIMAssetsItems;
        #endregion
        #region Method
        [Route("api/Report/MR")]
        [HttpGet]
        public HttpResponseMessage Get(DateTime pTransDate, string pName, string pPosition, string pPrepared, string pFFormat, string pObj)
        {
            try
            {
                lIReports = new Reports();
                lIMAssetsItems = new MAssetsItems();
                var _asset = lIMAssetsItems.ToBinding(JsonConvert.DeserializeObject<List<MAssetsItems>>(pObj));
                var _stream = lIReports.RptMR(pTransDate, pName, pPosition, pPrepared, pFFormat, _asset);
                return ResponseMsg(_stream);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/Report/ExportToExcel")]
        [HttpGet]
        public HttpResponseMessage Get(DateTime pFrom, DateTime pTo)
        {
            try
            {
                lIReports = new Reports();
                var _stream = lIReports.RptExportExcel(pFrom, pTo);
                return ResponseMsg(_stream);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        private HttpResponseMessage ResponseMsg(Stream pSC)
        {
            var _response = new HttpResponseMessage(HttpStatusCode.OK);
            _response.Content = new StreamContent(pSC);
            _response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            _response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            _response.Content.Headers.ContentLength = pSC.Length;
            return _response;
        }
        #endregion
    }
}
