using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO.Interface
{
    public interface IMRsDAO
    {
        /// <summary>
        /// Get list of the MR assets items
        /// </summary>
        /// <param name="pCon"></param>
        /// <returns></returns>
        IList<AssetItem> Get(SqlConnection pCon);
        /// <summary>
        /// Get list of the MR assets items
        /// </summary>
        /// <param name="pMRId"></param>
        /// <param name="pCon"></param>
        /// <returns></returns>
        IList<MR> Get(long pMRId, SqlConnection pCon);
        /// <summary>
        /// Get list of the MR assets items
        /// </summary>
        /// <param name="pCon"></param>
        /// <param name="pAssetItemId"></param>
        /// <returns></returns>
        IList<MR> Get(SqlConnection pCon, long pAssetItemId);
        /// <summary>
        /// Get list of the MR assets items
        /// </summary>
        /// <param name="pFrom"></param>
        /// <param name="pTo"></param>
        /// <param name="pCon"></param>
        /// <returns></returns>
        IList<AssetItem> Get(DateTime pFrom, DateTime pTo, SqlConnection pCon);
        /// <summary>
        /// Insert MR
        /// </summary>
        /// <param name="pEmployeeId"></param>
        /// <param name="pAssetItemId"></param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        void Insert(long pEmployeeId, long pAssetItemId, long pPreparedBy, string pTransBy, SqlTransaction pTran);
        /// <summary>
        /// Update MR
        /// </summary>
        /// <param name="pMRId"></param>
        /// <param name="pEmployeeId"></param>
        /// <param name="pAssetItemId"></param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        void Update(long pMRId, long pEmployeeId, long pAssetItemId, string pTransBy, SqlTransaction pTran);
        /// <summary>
        /// Update MR surrender
        /// </summary>
        /// <param name="pMRId"></param>
        /// <param name="pAssetItemId"></param>
        /// <param name="pRemarks"></param>
        /// <param name="pTransDate"></param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        void Update(long pMRId, long pAssetItemId, string pRemarks, DateTime pTransDate, string pTransBy, SqlTransaction pTran);
        /// <summary>
        /// Delete MR
        /// </summary>
        /// <param name="pMRId"></param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        void Delete(long pMRId, string pTransBy, SqlTransaction pTran);
    }
}
