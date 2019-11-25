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
    public class AssetsGroupsDAO : IAssetsGroupsDAO
    {
        /// <summary>
        /// Get list of assets groups
        /// </summary>
        /// <param name="pCon"></param>
        /// <returns></returns>
        public IList<AssetItem> Get(SqlConnection pCon)
        {
            try
            {
                var _assetitem = new List<AssetItem>();
                using (var _cmd = new SqlCommand("usp_GetAssetGroup"))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Connection = pCon;
                    using (SqlDataReader _rdr = _cmd.ExecuteReader())
                    {
                        try
                        {
                            _assetitem = ReadToEntity.Map<AssetItem>(_rdr);
                        }
                        catch (Exception ex) { throw ex; }
                    }
                }
                return _assetitem;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
