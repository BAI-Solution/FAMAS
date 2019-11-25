using AutoMap;
using Library.DAO.Interface;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO
{
    public class EmployeesDAO : IEmployeesDAO
    {
        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="pEmail"></param>
        /// <param name="pCon"></param>
        /// <returns></returns>
        public Employee Get(string pEmail, SqlConnection pCon)
        {
            try
            {
                Employee _emp = new Employee();
                using (var _cmd = new SqlCommand("usp_Authentication"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pEmail", SqlDbType.NVarChar, 100).Value = pEmail;
                    _cmd.Connection = pCon;

                    using (SqlDataReader _rdr = _cmd.ExecuteReader())
                        _emp = ReadToEntity.Map<Employee>(_rdr, new Employee());
                }
                return _emp;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Get employee
        /// </summary>
        /// <param name="pPosition"></param>
        /// <param name="pDepartment"></param>
        /// <param name="pBusinessUnit"></param>
        /// <param name="pCon"></param>
        /// <returns></returns>
        public IList<Employee> Get(string pDepartment, string pBusinessUnit, SqlConnection pCon)
        {
            try
            {
                var _employee = new List<Employee>();
                using (var _cmd = new SqlCommand("usp_GetEmployeeDesinate"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@pDepartment", SqlDbType.NVarChar, 100).Value = pDepartment;
                    _cmd.Parameters.Add("@pBusinessUnit", SqlDbType.NVarChar, 100).Value = pBusinessUnit;
                    _cmd.Connection = pCon;

                    using (SqlDataReader _rdr = _cmd.ExecuteReader())
                    {
                        _employee = ReadToEntity.Map<Employee>(_rdr);
                    }
                }
                return _employee;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
