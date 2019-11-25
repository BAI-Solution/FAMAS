using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLO.Interface
{
    public interface IEmployees
    {
        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="pMail"></param>
        /// <returns></returns>
        Employee Get(string pMail);
        /// <summary>
        /// Get employee
        /// </summary>
        /// <param name="pPosition"></param>
        /// <param name="pDepartment"></param>
        /// <param name="pBusinessUnit"></param>
        /// <returns></returns>
        IList<Employee> Get(string pDepartment, string pBusinessUnit);
    }
}
