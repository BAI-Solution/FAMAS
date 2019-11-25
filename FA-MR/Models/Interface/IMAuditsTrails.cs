using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA_MR.Models.Interface
{
    public interface IMAuditsTrails
    {
        /// <summary>
        /// To binding
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        AuditTrail ToBinding(MAuditsTrails pObj);
        /// <summary>
        /// To biniding
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        IList<AuditTrail> ToBinding(IList<MAuditsTrails> pObj);
        /// <summary>
        /// To model
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        MAuditsTrails ToModel(AuditTrail pObj);
        /// <summary>
        /// To model
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        IList<MAuditsTrails> ToModel(IList<AuditTrail> pObj);
    }
}
