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
    public class Dapartments: IDepartments
    {
        #region Local Variables
        IDepartmentsDAO lIDepartments;
        #endregion
        #region Construct
        public Dapartments()
        {
            lIDepartments = new DepartmentsDAO();
        }
        #endregion
        #region Method
        /// <summary>
        /// Get departments
        /// </summary>
        /// <returns></returns>
        public IList<Employee> Get()
        {
            try
            {
                try
                {
                    IList<Employee> _employee = new List<Employee>();
                    using (var _con = new SqlConnection(FixedAssets.Context))
                    {
                        _con.Open();
                        _employee = lIDepartments.Get(_con);
                    }
                    return _employee;
                }
                catch (Exception ex) { throw ex; }
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}
