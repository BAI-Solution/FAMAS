using FA_MR.Models.Interface;
using GlobalObject;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA_MR.Models
{
    public class MAuditsTrails: IMAuditsTrails
    {
        #region Construct
        public MAuditsTrails()
        {

        }
        #endregion
        #region Method
        /// <summary>
        /// To binding
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public AuditTrail ToBinding(MAuditsTrails pObj)
        {
            try
            {
                var _binding = new AuditTrail
                {
                    AuditTrailId = pObj.ATID,
                    TransBy = pObj.TRBY,
                    TransDate = pObj.TDTA,
                    TransTable = pObj.TTBL,
                    TransType = pObj.TTYP,
                    TransValue = pObj.TVAL
                };
                return _binding;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// To biniding
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public IList<AuditTrail> ToBinding(IList<MAuditsTrails> pObj)
        {
            var _binding = new List<AuditTrail>();
            if (!pObj.Count.Equals(0))
                _binding = pObj.Select(s => ToBinding(s)).ToList();

            return _binding;
        }
        /// <summary>
        /// To model
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public MAuditsTrails ToModel(AuditTrail pObj)
        {
            try
            {
                var _model = new MAuditsTrails
                {
                    ATID = pObj.AuditTrailId,
                    TDTA = pObj.TransDate,
                    TTYP = pObj.TransType,
                    TRBY = pObj.TransBy,
                    TTBL = pObj.TransTable,
                    TVAL = pObj.TransValue
                };

                return _model;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// To model
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public IList<MAuditsTrails> ToModel(IList<AuditTrail> pObj)
        {
            try
            {
                var _model = new List<MAuditsTrails>();
                if (!pObj.Count.Equals(0))
                    _model = pObj.Select(s => ToModel(s)).ToList();

                return _model;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
        #region Entity
        /// <summary>
        /// AuditTrailId
        /// </summary>
        public long ATID { get; set; }
        /// <summary>
        /// TransType
        /// </summary>
        public string TTYP { get; set; } = string.Empty;
        /// <summary>
        /// TransDate
        /// </summary>
        public DateTime TDTA { get; set; } = DefaultValue.datetime;
        /// <summary>
        /// TransTable
        /// </summary>
        public string TTBL { get; set; } = string.Empty;
        /// <summary>
        /// TransBy
        /// </summary>
        public string TRBY { get; set; } = string.Empty;
        /// <summary>
        /// TransValue
        /// </summary>
        public string TVAL { get; set; } = string.Empty;
        #endregion
    }
}