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
    public class AssetsTypes : IAssetsTypes
    {
        #region Local Variables
        IAssetsTypesDAO lIAssetsCodes;
        #endregion
        #region Construct
        public AssetsTypes()
        {
            lIAssetsCodes = new AssetsTypesDAO();
        }
        #endregion
        #region Method
        /// <summary>
        /// Get list of the assets codes
        /// </summary>
        /// <returns></returns>
        public IList<AssetItem> Get()
        {
            try
            {
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    return lIAssetsCodes.Get(_con);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}
