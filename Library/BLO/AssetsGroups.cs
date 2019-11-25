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
    public class AssetsGroups : IAssetsGroups
    {
        #region Local Variables
        IAssetsGroupsDAO lIAssetsGroups;
        #endregion
        #region Construct
        public AssetsGroups()
        {
            lIAssetsGroups = new AssetsGroupsDAO();
        }
        #endregion
        #region Method
        /// <summary>
        /// Get list of assets groups
        /// </summary>
        /// <returns></returns>
        public IList<AssetItem> Get()
        {
            try
            {
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    return lIAssetsGroups.Get(_con);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}
