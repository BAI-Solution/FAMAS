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
    public class Positions : IPositions
    {
        #region Local Variables
        IPositionsDAO lIPositions;
        #endregion
        #region Construct
        public Positions()
        {
            lIPositions = new PositionsDAO();
        }
        #endregion
        #region Method
        /// <summary>
        /// Get positions
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
                        _employee = lIPositions.Get(_con);
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
