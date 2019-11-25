using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLO.Interface
{
    public interface IPositions
    {
        /// <summary>
        /// Get positions
        /// </summary>
        /// <returns></returns>
        IList<Employee> Get();
    }
}
