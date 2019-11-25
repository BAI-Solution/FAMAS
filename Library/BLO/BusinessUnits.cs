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
    public class BusinessUnits: IBusinessUnits
    {
        #region Local Variables
        IBusinessUnitsDAO lIBusinessUnits;
        #endregion
        #region Construct
        public BusinessUnits()
        {
            lIBusinessUnits = new BusinessUnitsDAO();
        }
        #endregion
        #region Method
        /// <summary>
        /// Get business units
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
                        _employee = lIBusinessUnits.Get(_con);
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
