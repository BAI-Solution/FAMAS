using GlobalObject;
using Library.BLO.Interface;
using Library.DAO;
using Library.DAO.Interface;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLO
{
    public class MRs: IMRs
    {
        #region Local Variables
        IMRsDAO lIMRs;
        IAssetsItemsDAO lIAssetsItems;
        #endregion
        #region Construct
        public MRs()
        {
            lIMRs = new MRsDAO();
            lIAssetsItems = new AssetsItemsDAO();
        }
        #endregion
        #region Method
        /// <summary>
        /// Get list of the MR assets items
        /// </summary>
        /// <returns></returns>
        public IList<AssetItem> Get()
        {
            try
            {
                IList<AssetItem> _mr = new List<AssetItem>();
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    _mr = lIMRs.Get(_con);
                }
                return _mr;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Get list of the MR assets items
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pIdType"></param>
        /// <returns></returns>
        public IList<MR> Get(long pId, string pIdType)
        {
            try
            {
                IList<MR> _mr = new List<MR>();
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    if (pIdType == "MRId")
                        _mr = lIMRs.Get(pId, _con);
                    else if (pIdType == "AssetItemId")
                        _mr = lIMRs.Get(_con, pId);
                }
                return _mr;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Get list of the MR assets items
        /// </summary>
        /// <param name="pFrom"></param>
        /// <param name="pTo"></param>
        /// <returns></returns>
        public IList<AssetItem> Get(DateTime pFrom, DateTime pTo)
        {
            try
            {
                IList<AssetItem> _mr = new List<AssetItem>();
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    _mr = lIMRs.Get(pFrom, pTo, _con);
                }
                return _mr;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Insert MR
        /// </summary>
        /// <param name="pObj"></param>
        /// <param name="pTransBy"></param>
        public void Insert(IList<MR> pObj, string pTransBy, long pPreparedBy)
        {
            try
            {
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    using (var _tran = _con.BeginTransaction())
                    {
                        try
                        {
                            foreach (var _item in pObj)
                            {
                                _item.Remarks = string.Empty;
                                _item.PreparedBy = pPreparedBy;
                                if (_item.EmployeeId.Equals(0))
                                    throw new Exception("EmployeeId is zero");
                                else if(_item.AssetItemId.Equals(0))
                                    throw new Exception("AssetItemId is zero");
                                else if (string.IsNullOrEmpty(pTransBy))
                                    throw new Exception("Transaction By is null or empty");
                                else if (pPreparedBy.Equals(0))
                                    throw new Exception("Prepared By is null or empty");

                                lIMRs.Insert(_item.EmployeeId, _item.AssetItemId, pPreparedBy, pTransBy, _tran);
                                lIAssetsItems.Update(_item.AssetItemId, AssetStatus.Assigned.ToString(), _item.Remarks, pTransBy, _tran);
                            }
                            
                            _tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            _tran.Rollback();
                            throw ex; 
                        }
                    }
                    
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Update MR
        /// </summary>
        /// <param name="pMRId"></param>
        /// <param name="pEmployeeId"></param>
        /// <param name="pAssetItemId"></param>
        /// <param name="pTransBy"></param>
        public void Update(long pMRId, long pEmployeeId, long pAssetItemId, string pTransBy)
        {
            try
            {
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    using (var _tran = _con.BeginTransaction())
                    {
                        try
                        {
                            if (pMRId.Equals(0))
                                throw new Exception("MRId is zero");
                            else if (pEmployeeId.Equals(0))
                                throw new Exception("EmployeeId is zero");
                            else if (pAssetItemId.Equals(0))
                                throw new Exception("AssetItemId is zero");
                            else if (string.IsNullOrEmpty(pTransBy))
                                throw new Exception("Transaction By is null or empty");

                            lIMRs.Update(pMRId, pEmployeeId, pAssetItemId, pTransBy, _tran);

                            _tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            _tran.Rollback();
                            throw ex;
                        }
                    }

                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Update MR surrender
        /// </summary>
        /// <param name="pObj"></param>
        /// <param name="pTransBy"></param>
        public void Update(IList<MR> pObj, string pTransBy)
        {
            try
            {
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    using (var _tran = _con.BeginTransaction())
                    {
                        try
                        {
                            foreach (var _item in pObj)
                            {
                                if (_item.MRId.Equals(0))
                                    throw new Exception("MRId is zero");
                                else if (_item.AssetItemId.Equals(0))
                                    throw new Exception("AssetItemId is zero");
                                else if (string.IsNullOrEmpty(pTransBy))
                                    throw new Exception("Transaction By is null or empty");
                                else if (_item.TransDate.Date.Equals(DefaultValue.datetime.Date))
                                    throw new Exception("Transaction Date is null or empty");

                                lIMRs.Update(_item.MRId, _item.AssetItemId, _item.Remarks, _item.TransDate, pTransBy, _tran);
                            }

                            _tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            _tran.Rollback();
                            throw ex;
                        }
                    }

                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Delete MR
        /// </summary>
        /// <param name="pMRId"></param>
        /// <param name="pTransBy"></param>
        public void Delete(long pMRId, string pTransBy)
        {
            try
            {
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    using (var _tran = _con.BeginTransaction())
                    {
                        try
                        {
                            if (pMRId.Equals(0))
                                throw new Exception("MRId is zero");
                            else if (string.IsNullOrEmpty(pTransBy))
                                throw new Exception("Transaction By is null or empty");

                            lIMRs.Delete(pMRId, pTransBy, _tran);

                            _tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            _tran.Rollback();
                            throw ex;
                        }
                    }

                }
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}
