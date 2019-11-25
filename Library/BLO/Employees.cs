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
    public class Employees: IEmployees
    {
        #region Local Variables
        IEmployeesDAO lIEmployee;
        #endregion
        #region Construct
        public Employees()
        {
            lIEmployee = new EmployeesDAO();
        }
        #endregion
        #region Method
        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="pMail"></param>
        /// <returns></returns>
        public Employee Get(string pMail)
        {
            try
            {
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    return lIEmployee.Get(pMail, _con);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Get employee
        /// </summary>
        /// <param name="pPosition"></param>
        /// <param name="pDepartment"></param>
        /// <param name="pBusinessUnit"></param>
        /// <returns></returns>
        public IList<Employee> Get(string pDepartment, string pBusinessUnit)
        {
            try
            {
                IList<Employee> _employee = new List<Employee>();
                using (var _con = new SqlConnection(FixedAssets.Context))
                {
                    _con.Open();
                    _employee = lIEmployee.Get(pDepartment, pBusinessUnit, _con);
                }
                return _employee;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}
