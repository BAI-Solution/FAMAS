using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLO.Interface
{
    public interface IDepartments
    {
        /// <summary>
        /// Get departments
        /// </summary>
        /// <returns></returns>
        IList<Employee> Get();
    }
}
