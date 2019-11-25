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
    public class UOMsDAO : IUOMsDAO
    {
        /// <summary>
        /// Get list of unit of measure
        /// </summary>
        /// <param name="pCon"></param>
        /// <returns></returns>
        public IList<AssetItem> Get(SqlConnection pCon)
        {
            try
            {
                try
                {
                    var _uom = new List<AssetItem>();
                    using (var _cmd = new SqlCommand("usp_GetUOM"))
                    {
                        _cmd.CommandType = CommandType.StoredProcedure;
                        _cmd.Connection = pCon;

                        using (SqlDataReader _rdr = _cmd.ExecuteReader())
                        {
                            try
                            {
                                _uom = ReadToEntity.Map<AssetItem>(_rdr);
                            }
                            catch (Exception ex) { throw ex; }
                        }
                    }
                    return _uom;
                }
                catch (Exception ex) { throw ex; }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
