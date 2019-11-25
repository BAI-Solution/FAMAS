using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO.Interface
{
    interface IAssetsTypesDAO
    {
        /// <summary>
        /// Get list of assets codes
        /// </summary>
        /// <param name="pCon"></param>
        /// <returns></returns>
        IList<AssetItem> Get(SqlConnection pCon);
    }
}
