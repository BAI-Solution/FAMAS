using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLO.Interface
{
    public interface IAssetsItems
    {
        /// <summary>
        /// Get list of assets items
        /// </summary>
        /// <returns></returns>
        IList<AssetItem> Get();
        /// <summary>
        /// Get list of assets items
        /// </summary>
        /// <param name="pAssetGroup"></param>
        /// <param name="pAssetType"></param>
        /// <returns></returns>
        IList<AssetItem> Get(string pAssetGroup, string pAssetType);
        /// <summary>
        /// Get list of assets items
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        IList<AssetItem> Get(IList<AssetItem> pObj);
        /// Get list of assets items assigned
        /// </summary>
        /// <param name="pCon"></param>
        /// <param name="pStatus"></param>
        /// <returns></returns>
        IList<AssetItem> Get(string pStatus);
        /// <summary>
        /// Insert assets items
        /// </summary>
        /// <param name="pObj">Entity</param>
        /// <param name="pTransBy">Transact By</param>
        void Insert(IList<AssetItem> pObj, string pTransBy);
        /// <summary>
        /// Insert assets items
        /// </summary>
        /// <param name="pObj"></param>
        /// <param name="pTransBy"></param>
        void Insert(AssetItem pObj, string pTransBy);
        /// <summary>
        /// Update assets items
        /// </summary>
        /// <param name="pObj">Entity</param>
        /// <param name="pTransBy">Transact By</param>
        void Update(IList<AssetItem> pObj, string pTransBy);
        /// <summary>
        /// Update assets items
        /// </summary>
        /// <param name="pObj"></param>
        /// <param name="pTransBy"></param>
        void Update(AssetItem pObj, string pTransBy);
        /// <summary>
        ///  Update assets status
        /// </summary>
        /// <param name="pTransBy"></param>
        /// <param name="pObj"></param>
        void Update(string pTransBy, IList<AssetItem> pObj);
        /// <summary>
        /// Delete assets items
        /// </summary>
        /// <param name="pAssetId"></param>
        /// <param name="pTransBy">Transact By</param>
        void Delete(long pAssetId, string pTransBy);
        /// <summary>
        /// Sync insert assets items
        /// </summary>
        /// <param name="pObj">Entity</param>
        /// <param name="pTransBy">Transact By</param>
        void Sync(IList<AssetItem> pObj, string pTransBy);
        /// <summary>
        /// Sync update assets items
        /// </summary>
        /// <param name="pTransBy">Transact By</param>
        /// <param name="pObj">Entity</param>
        void Sync(string pTransBy, IList<AssetItem> pObj);
    }
}
