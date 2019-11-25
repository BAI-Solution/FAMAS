using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO.Interface
{
    public interface IEmployeesDAO
    {
        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="pEmail"></param>
        /// <param name="pCon"></param>
        /// <returns></returns>
        Employee Get(string pEmail, SqlConnection pCon);
        /// <summary>
        /// Get employee
        /// </summary>
        /// <param name="pPosition"></param>
        /// <param name="pDepartment"></param>
        /// <param name="pBusinessUnit"></param>
        /// <param name="pCon"></param>
        /// <returns></returns>
        IList<Employee> Get(string pDepartment, string pBusinessUnit, SqlConnection pCon);
    }
}
