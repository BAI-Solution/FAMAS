using Library.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLO.Interface
{
    public interface IReports
    {
        /// <summary>
        /// Generate MR report
        /// </summary>
        /// <param name="pTransDate"></param>
        /// <param name="pName"></param>
        /// <param name="pPosition"></param>
        /// <param name="pPrepared"></param>
        /// <param name="pFFormat"></param>
        /// <param name="pObj"></param>
        /// <returns></returns>
        Stream RptMR(DateTime pTransDate, string pName, string pPosition, string pPrepared, string pFFormat, IList<AssetItem> pObj);
        /// <summary>
        /// Export to excel
        /// </summary>
        /// <param name="pFrom"></param>
        /// <param name="pTo"></param>
        /// <returns></returns>
        Stream RptExportExcel(DateTime pFrom, DateTime pTo);

    }
}
