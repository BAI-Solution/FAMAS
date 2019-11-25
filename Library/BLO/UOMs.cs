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
    public class UOMs : IUOMs
    {
        #region Local Variables
        IUOMsDAO lIUOMs;
        #endregion
        #region Construct
        public UOMs()
        {
            lIUOMs = new UOMsDAO();
        }
        #endregion
        #region Method
        /// <summary>
        /// Get list of unit of measure
        /// </summary>
        /// <returns></returns>
        public IList<AssetItem> Get()
        {
            try
            {
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    return lIUOMs.Get(_con);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}
