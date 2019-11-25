using GlobalObject;
using Library.BLO.Interface;
using Library.DAO;
using Library.DAO.Interface;
using Library.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLO
{
    public class AssetsItems: IAssetsItems
    {
        #region Local Variables
        IAssetsItemsDAO lIAssetsItems;
        #endregion
        #region Construct
        public AssetsItems()
        {
            lIAssetsItems = new AssetsItemsDAO();
        }
        #endregion
        #region Method
        /// <summary>
        /// Get list of assets items
        /// </summary>
        /// <returns></returns>
        public IList<AssetItem> Get()
        {
            try
            {
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    return lIAssetsItems.Get(_con);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Get list of assets items
        /// </summary>
        /// <param name="pAssetGroup"></param>
        /// <param name="pAssetType"></param>
        /// <returns></returns>
        public IList<AssetItem> Get(string pAssetGroup, string pAssetType)
        {
            try
            {
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    if (string.IsNullOrEmpty(pAssetGroup))
                        throw new Exception("Asset Group is empty or null");
                    else if (string.IsNullOrEmpty(pAssetType))
                        throw new Exception("Asset Type is empty or null");

                    _con.Open();
                    return lIAssetsItems.Get(pAssetGroup, pAssetType, _con);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Get list of assets items
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public IList<AssetItem> Get(IList<AssetItem> pObj)
        {
            try
            {
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    string _json = JsonConvert.SerializeObject(pObj.Select(s => s.AssetItemId).ToList());
                    return lIAssetsItems.Get(_json, _con);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Get list of assets items assigned
        /// </summary>
        /// <param name="pCon"></param>
        /// <param name="pStatus"></param>
        /// <returns></returns>
        public IList<AssetItem> Get(string pStatus)
        {
            try
            {
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    return lIAssetsItems.Get(_con, pStatus);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Insert assets items
        /// </summary>
        /// <param name="pObj">Entity</param>
        /// <param name="pTransBy">Transact By</param>
        public void Insert(IList<AssetItem> pObj, string pTransBy)
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
                            foreach (var _obj in pObj)
                            {
                                if (string.IsNullOrEmpty(_obj.AssetGroup))
                                    throw new Exception("Asset Group is empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetCode))
                                    throw new Exception("Asset Code is empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetName))
                                    throw new Exception("Asset Name is empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetType))
                                    throw new Exception("Asset Type is empty or null");
                                else if (_obj.UnitCost.Equals(0))
                                    throw new Exception("Unit Cost is zero");
                                else if (string.IsNullOrEmpty(_obj.SerialNumber))
                                    throw new Exception("Serial Number is empty or null");
                                else if (_obj.UsefulLife.Equals(0))
                                    throw new Exception("Useful Life is zero");
                                else if (_obj.ServiceDate.Date.Equals(DefaultValue.datetime.Date))
                                    throw new Exception("Date Service is null or below 1754/1/1");
                                else if (string.IsNullOrEmpty(pTransBy))
                                    throw new Exception("Transaction By is empty or null");

                                lIAssetsItems.Insert(_obj, pTransBy, _tran);
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
        /// Insert assets items
        /// </summary>
        /// <param name="pObj"></param>
        /// <param name="pTransBy"></param>
        public void Insert(AssetItem pObj, string pTransBy)
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
                            if (string.IsNullOrEmpty(pObj.AssetGroup))
                                throw new Exception("Asset Group is empty or null");
                            else if (string.IsNullOrEmpty(pObj.AssetCode))
                                throw new Exception("Asset Code is empty or null");
                            else if (string.IsNullOrEmpty(pObj.AssetName))
                                throw new Exception("Asset Name is empty or null");
                            else if (string.IsNullOrEmpty(pObj.AssetType))
                                throw new Exception("Asset Type is empty or null");
                            else if (pObj.UnitCost.Equals(0))
                                throw new Exception("Unit Cost is zero");
                            else if (string.IsNullOrEmpty(pObj.SerialNumber))
                                throw new Exception("Serial Number is empty or null");
                            else if (pObj.UsefulLife.Equals(0))
                                throw new Exception("Useful Life is zero");
                            else if (pObj.ServiceDate.Date.Equals(DefaultValue.datetime.Date))
                                throw new Exception("Date Service is null or below 1754/1/1");
                            else if (string.IsNullOrEmpty(pTransBy))
                                throw new Exception("Transaction By is empty or null");

                            lIAssetsItems.Insert(pObj, pTransBy, _tran);

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
        /// Update assets items
        /// </summary>
        /// <param name="pObj">Entity</param>
        /// <param name="pTransBy">Transact By</param>
        public void Update(IList<AssetItem> pObj, string pTransBy)
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
                            foreach (var _obj in pObj)
                            {
                                if (_obj.AssetItemId.Equals(0))
                                    throw new Exception("Asset Item ID is zero");
                                else if (string.IsNullOrEmpty(_obj.AssetGroup))
                                    throw new Exception("Asset Group is empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetCode))
                                    throw new Exception("Asset Code is empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetName))
                                    throw new Exception("Asset Name is empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetType))
                                    throw new Exception("Asset Type is empty or null");
                                else if (_obj.UnitCost.Equals(0))
                                    throw new Exception("Unit Cost is zero");
                                else if (string.IsNullOrEmpty(_obj.SerialNumber))
                                    throw new Exception("Serial Number is empty or null");
                                else if (_obj.UsefulLife.Equals(0))
                                    throw new Exception("Useful Life is zero");
                                else if (_obj.ServiceDate.Date.Equals(DefaultValue.datetime.Date))
                                    throw new Exception("Date Service is null or below 1754/1/1");
                                else if (string.IsNullOrEmpty(pTransBy))
                                    throw new Exception("Transaction By is empty or null");

                                lIAssetsItems.Update(_obj, pTransBy, _tran);
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
        /// Update assets items
        /// </summary>
        /// <param name="pObj"></param>
        /// <param name="pTransBy"></param>
        public void Update(AssetItem pObj, string pTransBy)
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
                            if (pObj.AssetItemId.Equals(0))
                                throw new Exception("Asset Item ID is zero");
                            else if (string.IsNullOrEmpty(pObj.AssetGroup))
                                throw new Exception("Asset Group is empty or null");
                            else if (string.IsNullOrEmpty(pObj.AssetCode))
                                throw new Exception("Asset Code is empty or null");
                            else if (string.IsNullOrEmpty(pObj.AssetName))
                                throw new Exception("Asset Name is empty or null");
                            else if (string.IsNullOrEmpty(pObj.AssetType))
                                throw new Exception("Asset Type is empty or null");
                            else if (pObj.UnitCost.Equals(0))
                                throw new Exception("Unit Cost is zero");
                            else if (string.IsNullOrEmpty(pObj.SerialNumber))
                                throw new Exception("Serial Number is empty or null");
                            else if (pObj.UsefulLife.Equals(0))
                                throw new Exception("Useful Life is zero");
                            else if (pObj.ServiceDate.Date.Equals(DefaultValue.datetime.Date))
                                throw new Exception("Date Service is null or below 1754/1/1");
                            else if (string.IsNullOrEmpty(pTransBy))
                                throw new Exception("Transaction By is empty or null");

                            lIAssetsItems.Update(pObj, pTransBy, _tran);

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
        ///  Update assets status
        /// </summary>
        /// <param name="pTransBy"></param>
        /// <param name="pObj"></param>
        public void Update(string pTransBy, IList<AssetItem> pObj)
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
                                if (_item.AssetItemId.Equals(0))
                                    throw new Exception("Asset Item ID is zero");
                                else if (string.IsNullOrEmpty(_item.AssetStatus))
                                    throw new Exception("Asset Status is empty or null");
                                else if (string.IsNullOrEmpty(pTransBy))
                                    throw new Exception("Transact By is empty or null");

                                lIAssetsItems.Update(_item.AssetItemId, _item.AssetStatus, _item.Remarks, pTransBy, _tran);
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
        /// Delete assets items
        /// </summary>
        /// <param name="pAssetId"></param>
        /// <param name="pTransBy">Transact By</param>
        public void Delete(long pAssetId, string pTransBy)
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
                            if (pAssetId.Equals(0))
                                throw new Exception("Asset Item ID is zero");
                            else if (string.IsNullOrEmpty(pTransBy))
                                throw new Exception("Transact By is empty or null");

                            lIAssetsItems.Delete(pAssetId, pTransBy, _tran);
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
        /// Sync insert assets items
        /// </summary>
        /// <param name="pObj">Entity</param>
        /// <param name="pTransBy">Transact By</param>
        public void Sync(IList<AssetItem> pObj, string pTransBy)
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
                            foreach (var _obj in pObj)
                            {
                                if (string.IsNullOrEmpty(_obj.AssetGroup))
                                    throw new Exception("Asset Group is empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetCode))
                                    throw new Exception("Asset Code is empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetNumber))
                                    throw new Exception("Asset Number is empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetName))
                                    throw new Exception("Asset Name is empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetType))
                                    throw new Exception("Asset Type is empty or null");
                                else if (_obj.UnitCost.Equals(0))
                                    throw new Exception("Unit Cost is zero");
                                else if (string.IsNullOrEmpty(_obj.SerialNumber))
                                    throw new Exception("Serial Number is empty or null");
                                else if (_obj.UsefulLife.Equals(0))
                                    throw new Exception("Useful Life is zero");
                                else if (_obj.ServiceDate.Date.Equals(DefaultValue.datetime.Date))
                                    throw new Exception("Date Service is null or below 1754/1/1");
                                else if (string.IsNullOrEmpty(pTransBy))
                                    throw new Exception("Transaction By is empty or null");

                                lIAssetsItems.Sync(_obj, pTransBy, _tran);
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
        /// Sync update assets items
        /// </summary>
        /// <param name="pTransBy">Transact By</param>
        /// <param name="pObj">Entity</param>
        public void Sync(string pTransBy, IList<AssetItem> pObj)
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
                            foreach (var _obj in pObj)
                            {
                                if (_obj.AssetItemId.Equals(0))
                                    throw new Exception("Asset Item ID is zero");
                                else if (string.IsNullOrEmpty(_obj.AssetNumber))
                                    throw new Exception("Asset Number is empty empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetGroup))
                                    throw new Exception("Asset Group is empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetCode))
                                    throw new Exception("Asset Code is empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetName))
                                    throw new Exception("Asset Name is empty or null");
                                else if (string.IsNullOrEmpty(_obj.AssetType))
                                    throw new Exception("Asset Type is empty or null");
                                else if (_obj.UnitCost.Equals(0))
                                    throw new Exception("Unit Cost is zero");
                                else if (string.IsNullOrEmpty(_obj.SerialNumber))
                                    throw new Exception("Serial Number is empty or null");
                                else if (_obj.UsefulLife.Equals(0))
                                    throw new Exception("Useful Life is zero");
                                else if (_obj.ServiceDate.Date.Equals(DefaultValue.datetime.Date))
                                    throw new Exception("Date Service is null or below 1754/1/1");
                                else if (string.IsNullOrEmpty(pTransBy))
                                    throw new Exception("Transaction By is empty or null");

                                lIAssetsItems.Sync(_tran, pTransBy, _obj);
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
        #endregion
    }
}
