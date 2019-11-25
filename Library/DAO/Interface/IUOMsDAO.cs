using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO.Interface
{
    public interface IUOMsDAO
    {
        /// <summary>
        /// Get list of unit of measure
        /// </summary>
        /// <param name="pCon"></param>
        /// <returns></returns>
        IList<AssetItem> Get(SqlConnection pCon);
    }
}
