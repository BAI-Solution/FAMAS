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
    public class MRsDAO : IMRsDAO
    {
        /// <summary>
        /// Get list of the MR assets items
        /// </summary>
        /// <param name="pCon"></param>
        /// <returns></returns>
        public IList<AssetItem> Get(SqlConnection pCon)
        {
            try
            {
                var _mr = new List<AssetItem>();
                using (var _cmd = new SqlCommand("usp_GetMRs"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Connection = pCon;

                    using (SqlDataReader _rdr = _cmd.ExecuteReader())
                    {
                        try
                        {
                            _mr = ReadToEntity.Map<AssetItem>(_rdr);
                        }
                        catch (Exception ex) { throw ex; }
                    }
                }
                return _mr;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Get list of the MR assets items
        /// </summary>
        /// <param name="pMRId"></param>
        /// <param name="pCon"></param>
        /// <returns></returns>
        public IList<MR> Get(long pMRId, SqlConnection pCon)
        {
            try
            {
                var _mr = new List<MR>();
                using (var _cmd = new SqlCommand("usp_GetMRById"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pMRId", SqlDbType.BigInt).Value = pMRId;
                    _cmd.Connection = pCon;

                    using (SqlDataReader _rdr = _cmd.ExecuteReader())
                    {
                        try
                        {
                            _mr = ReadToEntity.Map<MR>(_rdr);
                        }
                        catch (Exception ex) { throw ex; }
                    }
                }
                return _mr;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Get list of the MR assets items
        /// </summary>
        /// <param name="pCon"></param>
        /// <param name="pAssetItemId"></param>
        /// <returns></returns>
        public IList<MR> Get(SqlConnection pCon, long pAssetItemId)
        {
            try
            {
                var _mr = new List<MR>();
                using (var _cmd = new SqlCommand("usp_GetMRAssetsItems"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pAssetItemId", SqlDbType.BigInt).Value = pAssetItemId;
                    _cmd.Connection = pCon;

                    using (SqlDataReader _rdr = _cmd.ExecuteReader())
                    {
                        try
                        {
                            _mr = ReadToEntity.Map<MR>(_rdr);
                        }
                        catch (Exception ex) { throw ex; }
                    }
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
        /// <param name="pCon"></param>
        /// <returns></returns>
        public IList<AssetItem> Get(DateTime pFrom, DateTime pTo, SqlConnection pCon)
        {
            try
            {
                var _mr = new List<AssetItem>();
                using (var _cmd = new SqlCommand("usp_GetMRByDateRange"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pFDate", SqlDbType.DateTime).Value = pFrom;
                    _cmd.Parameters.Add("@pEdate", SqlDbType.DateTime).Value = pTo;
                    _cmd.Connection = pCon;

                    using (SqlDataReader _rdr = _cmd.ExecuteReader())
                    {
                        try
                        {
                            _mr = ReadToEntity.Map<AssetItem>(_rdr);
                        }
                        catch (Exception ex) { throw ex; }
                    }
                }
                return _mr;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Insert MR
        /// </summary>
        /// <param name="pEmployeeId"></param>
        /// <param name="pAssetItemId"></param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        public void Insert(long pEmployeeId, long pAssetItemId, long pPreparedBy, string pTransBy, SqlTransaction pTran)
        {
            try
            {
                var _mr = new List<MR>();
                using (var _cmd = new SqlCommand("usp_InsertMR"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pEmployeeId", SqlDbType.BigInt).Value = pEmployeeId;
                    _cmd.Parameters.Add("@pAssetItemId", SqlDbType.BigInt).Value = pAssetItemId;
                    _cmd.Parameters.Add("@pPreparedBy", SqlDbType.BigInt).Value = pPreparedBy;
                    _cmd.Parameters.Add("@pTransBy", SqlDbType.NVarChar, 100).Value = pTransBy;
                    _cmd.Connection = pTran.Connection;
                    _cmd.Transaction = pTran;
                    _cmd.ExecuteNonQuery();
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
        /// <param name="pTran"></param>
        public void Update(long pMRId, long pEmployeeId, long pAssetItemId, string pTransBy, SqlTransaction pTran)
        {
            try
            {
                var _mr = new List<MR>();
                using (var _cmd = new SqlCommand("usp_UpdateMR"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pMRId", SqlDbType.BigInt).Value = pMRId;
                    _cmd.Parameters.Add("@pEmployeeId", SqlDbType.BigInt).Value = pEmployeeId;
                    _cmd.Parameters.Add("@pAssetItemId", SqlDbType.BigInt).Value = pAssetItemId;
                    _cmd.Parameters.Add("@pTransBy", SqlDbType.NVarChar, 100).Value = pTransBy;
                    _cmd.Connection = pTran.Connection;
                    _cmd.Transaction = pTran;
                    _cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Update MR surrender
        /// </summary>
        /// <param name="pMRId"></param>
        /// <param name="pAssetItemId"></param>
        /// <param name="pRemarks"></param>
        /// <param name="pTransDate"></param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        public void Update(long pMRId, long pAssetItemId, string pRemarks, DateTime pTransDate, string pTransBy, SqlTransaction pTran)
        {
            try
            {
                var _mr = new List<MR>();
                using (var _cmd = new SqlCommand("usp_UpdateMRSurrender"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pMRId", SqlDbType.BigInt).Value = pMRId;
                    _cmd.Parameters.Add("@pAssetItemId", SqlDbType.BigInt).Value = pAssetItemId;
                    _cmd.Parameters.Add("@pRemarks", SqlDbType.NVarChar, 250).Value = pRemarks;
                    _cmd.Parameters.Add("@pTransDate", SqlDbType.DateTime).Value = pTransDate;
                    _cmd.Parameters.Add("@pTransBy", SqlDbType.NVarChar, 100).Value = pTransBy;
                    _cmd.Connection = pTran.Connection;
                    _cmd.Transaction = pTran;
                    _cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Delete MR
        /// </summary>
        /// <param name="pMRId"></param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        public void Delete(long pMRId, string pTransBy, SqlTransaction pTran)
        {
            try
            {
                var _mr = new List<MR>();
                using (var _cmd = new SqlCommand("usp_DeleteMR"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pMRId", SqlDbType.BigInt).Value = pMRId;
                    _cmd.Parameters.Add("@pTransBy", SqlDbType.NVarChar, 100).Value = pTransBy;
                    _cmd.Connection = pTran.Connection;
                    _cmd.Transaction = pTran;
                    _cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
