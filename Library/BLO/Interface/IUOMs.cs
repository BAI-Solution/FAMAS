using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLO.Interface
{
    public interface IUOMs
    {
        /// <summary>
        /// Get list of unit of measure
        /// </summary>
        /// <returns></returns>
        IList<AssetItem> Get();
    }
}
