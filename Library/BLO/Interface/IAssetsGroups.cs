using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLO.Interface
{
    public interface IAssetsGroups
    {
        /// <summary>
        /// Get list of assets groups
        /// </summary>
        /// <returns></returns>
        IList<AssetItem> Get();
    }
}
