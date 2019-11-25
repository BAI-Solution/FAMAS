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
    public class DepartmentsDAO: IDepartmentsDAO
    {
        /// <summary>
        /// Get departments
        /// </summary>
        /// <param name="pCon"></param>
        /// <returns></returns>
        public IList<Employee> Get(SqlConnection pCon)
        {
            try
            {
                try
                {
                    var _employee = new List<Employee>();
                    using (var _cmd = new SqlCommand("usp_GetDepartment"))
                    {
                        _cmd.CommandType = CommandType.StoredProcedure;
                        _cmd.Connection = pCon;

                        using (SqlDataReader _rdr = _cmd.ExecuteReader())
                        {
                            try
                            {
                                _employee = ReadToEntity.Map<Employee>(_rdr);
                            }
                            catch (Exception ex) { throw ex; }
                        }
                    }
                    return _employee;
                }
                catch (Exception ex) { throw ex; }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
