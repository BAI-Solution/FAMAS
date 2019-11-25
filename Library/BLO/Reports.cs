using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using GlobalObject;
using Library.BLO.Interface;
using Library.DAO;
using Library.DAO.Interface;
using Library.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Library.BLO
{
    public class Reports : IReports
    {
        #region Local Variable
        IAssetsItemsDAO lIAssetsItems;
        IMRsDAO lIMRs;
        #endregion
        #region Construct
        public Reports()
        {
            lIAssetsItems = new AssetsItemsDAO();
            lIMRs = new MRsDAO();
        }
        #endregion
        #region Method
        /// <summary>
        /// Generate MR report
        /// </summary>
        /// <param name="pTransDate"></param>
        /// <param name="pName"></param>
        /// <param name="pPosition"></param>
        /// <param name="pPrepared"></param>
        /// <param name="pFFormat"></param>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public Stream RptMR(DateTime pTransDate, string pName, string pPosition, string pPrepared, string pFFormat, IList<AssetItem> pObj)
        {
            try
            {
                string _content = MRContent();
                string _json = JsonConvert.SerializeObject(pObj.Select(s => new { AssetItemId = s.AssetItemId }).ToList());
                IList<AssetItem> _assetItem = new List<AssetItem>();
                using (ReportDocument _rd = new ReportDocument())
                {
                    try
                    {
                        string _path = HttpContext.Current.Server.MapPath("~/Report/MR.rpt");
                        _rd.Load(_path);
                        using (var _con = new SqlConnection(FixedAssets.Context))
                        {
                            _con.Open();
                            _assetItem = lIAssetsItems.Get(_json, _con);
                        }
                        _rd.SetDataSource(_assetItem);
                        _rd.SetParameterValue("pTransDate", pTransDate.ToShortDateString());
                        _rd.SetParameterValue("pName", pName);
                        _rd.SetParameterValue("pPosition", pPosition);
                        _rd.SetParameterValue("pPrepared", pPrepared);
                        _rd.SetParameterValue("pMRContent", _content);

                        return _rd.ExportToStream(pFFormat == "PDF" ? ExportFormatType.PortableDocFormat : ExportFormatType.Excel);
                    }
                    catch (Exception ex) { throw ex; }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Export to excel
        /// </summary>
        /// <param name="pFrom"></param>
        /// <param name="pTo"></param>
        /// <returns></returns>
        public Stream RptExportExcel(DateTime pFrom, DateTime pTo)
        {
            using (ReportDocument _rd = new ReportDocument())
            {
                try
                {
                    string _path = HttpContext.Current.Server.MapPath("~/Report/AssignedItem.rpt");
                    _rd.Load(_path);
                    IList<AssetItem> _asset = new List<AssetItem>();
                    using (var _con = new SqlConnection(FixedAssets.Context))
                    {
                        _con.Open();
                        _asset = pFrom.Date.Equals(DefaultValue.datetime.Date) ? lIMRs.Get(_con) : lIMRs.Get(pFrom, pTo, _con);
                    }
                    string _type = pFrom.Date < DefaultValue.datetime.Date ? "All Assigned Fixed Assets" : pFrom.ToShortDateString() + " - " + pTo.ToShortDateString();
                    _rd.SetDataSource(_asset);
                    _rd.SetParameterValue("pType", _type);

                    return _rd.ExportToStream(ExportFormatType.Excel);
                }
                catch (Exception ex) { throw ex; }
            }
        }
        private string MRContent()
        {
            try
            {
                string _path = HttpContext.Current.Server.MapPath("~/Container/MRContent.txt");//"D:\\Projects\\FA-MR\\20190227\\Library\\Container\\MRContent.txt";
                string _content = File.ReadAllText(_path, Encoding.UTF8);

                return _content;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}
