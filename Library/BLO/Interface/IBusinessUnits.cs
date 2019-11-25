using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLO.Interface
{
    public interface IBusinessUnits
    {
        /// <summary>
        /// Get business units
        /// </summary>
        /// <returns></returns>
        IList<Employee> Get();
    }
}
