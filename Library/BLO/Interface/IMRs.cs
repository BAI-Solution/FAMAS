using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLO.Interface
{
    public interface IMRs
    {
        /// <summary>
        /// Get list of the MR assets items
        /// </summary>
        /// <returns></returns>
        IList<AssetItem> Get();
        /// <summary>
        /// Get list of the MR assets items
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pIdType"></param>
        /// <returns></returns>
        IList<MR> Get(long pId, string pIdType);
        /// <summary>
        /// Get list of the MR assets items
        /// </summary>
        /// <param name="pFrom"></param>
        /// <param name="pTo"></param>
        /// <returns></returns>
        IList<AssetItem> Get(DateTime pFrom, DateTime pTo);
        /// <summary>
        /// Insert MR
        /// </summary>
        /// <param name="pObj"></param>
        /// <param name="pTransBy"></param>
        void Insert(IList<MR> pObj, string pTransBy, long pPreparedBy);
        /// <summary>
        /// Update MR
        /// </summary>
        /// <param name="pMRId"></param>
        /// <param name="pEmployeeId"></param>
        /// <param name="pAssetItemId"></param>
        /// <param name="pTransBy"></param>
        void Update(long pMRId, long pEmployeeId, long pAssetItemId, string pTransBy);
        /// <summary>
        /// Update MR surrender
        /// </summary>
        /// <param name="pObj"></param>
        /// <param name="pTransBy"></param>
        void Update(IList<MR> pObj, string pTransBy);
        /// <summary>
        /// Delete MR
        /// </summary>
        /// <param name="pMRId"></param>
        /// <param name="pTransBy"></param>
        void Delete(long pMRId, string pTransBy);
    }
}
