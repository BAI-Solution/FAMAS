using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO.Interface
{
    public interface IDepartmentsDAO
    {
        /// <summary>
        /// Get departments
        /// </summary>
        /// <param name="pCon"></param>
        /// <returns></returns>
        IList<Employee> Get(SqlConnection pCon);
    }
}
