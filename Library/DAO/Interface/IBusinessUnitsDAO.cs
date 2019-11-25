using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO.Interface
{
    public interface IBusinessUnitsDAO
    {
        /// <summary>
        /// Get business units
        /// </summary>
        /// <param name="pCon"></param>
        /// <returns></returns>
        IList<Employee> Get(SqlConnection pCon);
    }
}
