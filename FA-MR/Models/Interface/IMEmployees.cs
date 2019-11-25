using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA_MR.Models.Interface
{
    public interface IMEmployees
    {
        /// <summary>
        /// To binding
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        Employee ToBinding(MEmployees pObj);
        /// <summary>
        /// To biniding
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        IList<Employee> ToBinding(IList<MEmployees> pObj);
        /// <summary>
        /// To model
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        MEmployees ToModel(Employee pObj);
        /// <summary>
        /// To model
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        IList<MEmployees> ToModel(IList<Employee> pObj);
    }
}
