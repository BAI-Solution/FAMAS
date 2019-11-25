using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO.Interface
{
    interface IAssetsItemsDAO
    {
        /// <summary>
        /// Get list of assets items
        /// </summary>
        /// <param name="pCon">SqlConnection</param>
        /// <returns></returns>
        IList<AssetItem> Get(SqlConnection pCon);
        /// <summary>
        /// Get list of assets items
        /// </summary>
        /// <param name="pAssetGroup"></param>
        /// <param name="pAssetType"></param>
        /// <param name="pCon"></param>
        /// <returns></returns>
        IList<AssetItem> Get(string pAssetGroup, string pAssetType, SqlConnection pCon);
        /// <summary>
        /// Get list of assets items
        /// </summary>
        /// <param name="pAssetItemId"></param>
        /// <param name="pCon"></param>
        /// <returns></returns>
        IList<AssetItem> Get(string pAssetItemId, SqlConnection pCon);
        /// <summary>
        /// Get list of assets items assigned
        /// </summary>
        /// <param name="pCon"></param>
        /// <param name="pStatus"></param>
        /// <returns></returns>
        IList<AssetItem> Get(SqlConnection pCon, string pStatus);
        /// <summary>
        /// Insert assets items
        /// </summary>
        /// <param name="pObj">Entity</param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        void Insert(AssetItem pObj, string pTransBy, SqlTransaction pTran);
        /// <summary>
        /// Update assets items
        /// </summary>
        /// <param name="pObj">Entity</param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        void Update(AssetItem pObj, string pTransBy, SqlTransaction pTran);
        /// <summary>
        /// Update assets items
        /// </summary>
        /// <param name="pAssetId"></param>
        /// <param name="pAssetStatus"></param>
        /// <param name="pRemarks"></param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        void Update(long pAssetId, string pAssetStatus, string pRemarks, string pTransBy, SqlTransaction pTran);
        /// <summary>
        /// Delete asset item in assets items
        /// </summary>
        /// <param name="pAssetId"></param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        void Delete(long pAssetId, string pTransBy, SqlTransaction pTran);
        /// <summary>
        /// Sync insert assets items
        /// </summary>
        /// <param name="pObj">Entity</param>
        /// <param name="pTransBy"></param>
        /// <param name="pTran"></param>
        void Sync(AssetItem pObj, string pTransBy, SqlTransaction pTran);
        /// <summary>
        /// Sync update assets items
        /// </summary>
        /// <param name="pTran"></param>
        /// <param name="pTransBy"></param>
        /// <param name="pObj">Entity</param>
        void Sync(SqlTransaction pTran, string pTransBy, AssetItem pObj);
    }
}
