using AutoMap;
using Library.DAO.Interface;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO
{
    public class AssetsItemsDAO : IAssetsItemsDAO
    {
        /// <summary>
        /// Get list of assets items
        /// </summary>
        /// <param name="pCon"></param>
        /// <returns></returns>
        public IList<AssetItem> Get(SqlConnection pCon)
        {
            try
            {
                DataTable _dt = new DataTable();
                var _assetitem = new List<AssetItem>();
                using (var _cmd = new SqlCommand("usp_GetAssetItem"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Connection = pCon;
                    using (SqlDataReader _rdr = _cmd.ExecuteReader())
                    {
                        try
                        {
                            _assetitem = ReadToEntity.Map<AssetItem>(_rdr);
                        }
                        catch (Exception ex) { throw ex; }
                    }
                }
                return _assetitem;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Get list of assets items
        /// </summary>
        /// <param name="pAssetGroup"></param>
        /// <param name="pAssetType"></param>
        /// <param name="pCon"></param>
        /// <returns></returns>
        public IList<AssetItem> Get(string pAssetGroup, string pAssetType, SqlConnection pCon)
        {
            try
            {
                var _assetitem = new List<AssetItem>();
                using (var _cmd = new SqlCommand("usp_GetAssetItemByFiltered"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pAssetGroup", SqlDbType.NVarChar, 100).Value = pAssetGroup;
                    _cmd.Parameters.Add("@pAssetType", SqlDbType.NVarChar, 100).Value = pAssetType;
                    _cmd.Connection = pCon;

                    using (SqlDataReader _rdr = _cmd.ExecuteReader())
                    {
                        try
                        {
                            _assetitem = ReadToEntity.Map<AssetItem>(_rdr);
                        }
                        catch (Exception ex) { throw ex; }
                    }
                }
                return _assetitem;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Get list of assets items
        /// </summary>
        /// <param name="pAssetItemId"></param>
        /// <param name="pCon"></param>
        /// <returns></returns>
        public IList<AssetItem> Get(string pAssetItemId, SqlConnection pCon)
        {
            try
            {
                var _assetitem = new List<AssetItem>();
                using (var _cmd = new SqlCommand("usp_GetAssetItemById"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pAssetItemId", SqlDbType.NVarChar).Value = pAssetItemId;
                    _cmd.Connection = pCon;
                    using (SqlDataReader _rdr = _cmd.ExecuteReader())
                    {
                        try
                        {
                            _assetitem = ReadToEntity.Map<AssetItem>(_rdr);
                        }
                        catch (Exception ex) { throw ex; }
                    }
                }
                return _assetitem;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Get list of assets items assigned
        /// </summary>
        /// <param name="pCon"></param>
        /// <param name="pStatus"></param>
        /// <returns></returns>
        public IList<AssetItem> Get(SqlConnection pCon, string pStatus)
        {
            try
            {
                var _assetitem = new List<AssetItem>();
                using (var _cmd = new SqlCommand("usp_GetAssetItemByStatus"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pStatus", SqlDbType.NVarChar, 15).Value = pStatus;
                    _cmd.Connection = pCon;
                    using (SqlDataReader _rdr = _cmd.ExecuteReader())
                    {
                        try
                        {
                            _assetitem = ReadToEntity.Map<AssetItem>(_rdr);
                        }
                        catch (Exception ex) { throw ex; }
                    }
                }
                return _assetitem;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Insert assets items
        /// </summary>
        /// <param name="pObj">Entity</param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        public void Insert(AssetItem pObj, string pTransBy, SqlTransaction pTran)
            {
            try
            {
                using (var _cmd = new SqlCommand("usp_InsertAssetItem"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pAssetGroup", SqlDbType.NVarChar, 100).Value = pObj.AssetGroup;
                    _cmd.Parameters.Add("@pAssetCode", SqlDbType.NVarChar, 100).Value = pObj.AssetCode;
                    _cmd.Parameters.Add("@pAssetName", SqlDbType.NVarChar, 250).Value = pObj.AssetName;
                    _cmd.Parameters.Add("@pAssetType", SqlDbType.NVarChar, 50).Value = pObj.AssetType;
                    _cmd.Parameters.Add("@pUnitCost", SqlDbType.Decimal).Value = pObj.UnitCost;
                    _cmd.Parameters.Add("@pSerialNumber", SqlDbType.NVarChar, 100).Value = pObj.SerialNumber;
                    _cmd.Parameters.Add("@pUsefulLife", SqlDbType.Int).Value = pObj.UsefulLife;
                    _cmd.Parameters.Add("@pServiceDate", SqlDbType.DateTime).Value = pObj.ServiceDate;
                    _cmd.Parameters.Add("@pTransBy", SqlDbType.NVarChar, 100).Value = pTransBy;
                    _cmd.Connection = pTran.Connection;
                    _cmd.Transaction = pTran;
                    _cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Update assets items
        /// </summary>
        /// <param name="pObj">Entity</param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        public void Update(AssetItem pObj, string pTransBy, SqlTransaction pTran)
        {
            try
            {
                using (var _cmd = new SqlCommand("usp_UpdateAssetItem"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pAssetItemId", SqlDbType.BigInt).Value = pObj.AssetItemId;
                    _cmd.Parameters.Add("@pAssetGroup", SqlDbType.NVarChar, 100).Value = pObj.AssetGroup;
                    _cmd.Parameters.Add("@pAssetCode", SqlDbType.NVarChar, 100).Value = pObj.AssetCode;
                    _cmd.Parameters.Add("@pAssetName", SqlDbType.NVarChar, 250).Value = pObj.AssetName;
                    _cmd.Parameters.Add("@pAssetType", SqlDbType.NVarChar, 50).Value = pObj.AssetType;
                    _cmd.Parameters.Add("@pUnitCost", SqlDbType.Decimal).Value = pObj.UnitCost;
                    _cmd.Parameters.Add("@pSerialNumber", SqlDbType.NVarChar, 100).Value = pObj.SerialNumber;
                    _cmd.Parameters.Add("@pUsefulLife", SqlDbType.Int).Value = pObj.UsefulLife;
                    _cmd.Parameters.Add("@pServiceDate", SqlDbType.DateTime).Value = pObj.ServiceDate;
                    _cmd.Parameters.Add("@pTransBy", SqlDbType.NVarChar, 100).Value = pTransBy;
                    _cmd.Connection = pTran.Connection;
                    _cmd.Transaction = pTran;
                    _cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Update assets items
        /// </summary>
        /// <param name="pAssetId"></param>
        /// <param name="pAssetStatus"></param>
        /// <param name="pRemarks"></param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        public void Update(long pAssetId, string pAssetStatus, string pRemarks, string pTransBy, SqlTransaction pTran)
        {
            try
            {
                using (var _cmd = new SqlCommand("usp_UpdateAssetItemStatus"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pAssetId", SqlDbType.BigInt).Value = pAssetId;
                    _cmd.Parameters.Add("@pAssetStatus", SqlDbType.NVarChar, 50).Value = pAssetStatus;
                    _cmd.Parameters.Add("@pRemarks", SqlDbType.NVarChar, 250).Value = pRemarks;
                    _cmd.Parameters.Add("@pTransBy", SqlDbType.NVarChar, 100).Value = pTransBy;
                    _cmd.Connection = pTran.Connection;
                    _cmd.Transaction = pTran;
                    _cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Delete asset item in assets items
        /// </summary>
        /// <param name="pAssetId"></param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        public void Delete(long pAssetId, string pTransBy, SqlTransaction pTran)
        {
            try
            {
                using (var _cmd = new SqlCommand("usp_UpdateAssetItemType"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pAssetId", SqlDbType.BigInt).Value = pAssetId;
                    _cmd.Parameters.Add("@pTransBy", SqlDbType.DateTime).Value = pTransBy;
                    _cmd.Connection = pTran.Connection;
                    _cmd.Transaction = pTran;
                    _cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Sync insert assets items
        /// </summary>
        /// <param name="pObj">Entity</param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        public void Sync(AssetItem pObj, string pTransBy, SqlTransaction pTran)
        {
            try
            {
                using (var _cmd = new SqlCommand("usp_SyncInsertAssetItem"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pAssetGroup", SqlDbType.NVarChar, 100).Value = pObj.AssetGroup;
                    _cmd.Parameters.Add("@pAssetCode", SqlDbType.NVarChar, 100).Value = pObj.AssetCode;
                    _cmd.Parameters.Add("@pAssetNumber", SqlDbType.NVarChar, 100).Value = pObj.AssetNumber;
                    _cmd.Parameters.Add("@pAssetName", SqlDbType.NVarChar, 250).Value = pObj.AssetName;
                    _cmd.Parameters.Add("@pAssetType", SqlDbType.NVarChar, 50).Value = pObj.AssetType;
                    _cmd.Parameters.Add("@pUnitCost", SqlDbType.Decimal).Value = pObj.UnitCost;
                    _cmd.Parameters.Add("@pSerialNumber", SqlDbType.NVarChar, 100).Value = pObj.SerialNumber;
                    _cmd.Parameters.Add("@pUsefulLife", SqlDbType.Int).Value = pObj.UsefulLife;
                    _cmd.Parameters.Add("@pServiceDate", SqlDbType.DateTime).Value = pObj.ServiceDate;
                    _cmd.Parameters.Add("@pTransBy", SqlDbType.DateTime).Value = pTransBy;
                    _cmd.Connection = pTran.Connection;
                    _cmd.Transaction = pTran;
                    _cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Sync update assets items
        /// </summary>
        /// <param name="pTran"></param>
        /// <param name="pTransBy"></param>
        /// <param name="pObj">Entity</param>
        public void Sync(SqlTransaction pTran, string pTransBy, AssetItem pObj)
        {
            try
            {
                using (var _cmd = new SqlCommand("usp_SyncUpdateAssetItem"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pAssetItemId", SqlDbType.BigInt).Value = pObj.AssetItemId;
                    _cmd.Parameters.Add("@pAssetGroup", SqlDbType.NVarChar, 100).Value = pObj.AssetGroup;
                    _cmd.Parameters.Add("@pAssetCode", SqlDbType.NVarChar, 100).Value = pObj.AssetCode;
                    _cmd.Parameters.Add("@pAssetNumber", SqlDbType.NVarChar, 100).Value = pObj.AssetNumber;
                    _cmd.Parameters.Add("@pAssetName", SqlDbType.NVarChar, 250).Value = pObj.AssetName;
                    _cmd.Parameters.Add("@pAssetType", SqlDbType.NVarChar, 50).Value = pObj.AssetType;
                    _cmd.Parameters.Add("@pUnitCost", SqlDbType.Decimal).Value = pObj.UnitCost;
                    _cmd.Parameters.Add("@pSerialNumber", SqlDbType.NVarChar, 100).Value = pObj.SerialNumber;
                    _cmd.Parameters.Add("@pUsefulLife", SqlDbType.Int).Value = pObj.UsefulLife;
                    _cmd.Parameters.Add("@pServiceDate", SqlDbType.DateTime).Value = pObj.ServiceDate;
                    _cmd.Parameters.Add("@pTransBy", SqlDbType.DateTime).Value = pTransBy;
                    _cmd.Connection = pTran.Connection;
                    _cmd.Transaction = pTran;
                    _cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
