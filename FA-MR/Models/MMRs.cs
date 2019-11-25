using FA_MR.Models.Interface;
using GlobalObject;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA_MR.Models
{
    public class MMRs: IMMRs
    {
        #region Construct
        public MMRs()
        {

        }
        #endregion
        #region Method
        /// <summary>
        /// To binding
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public MR ToBinding(MMRs pObj)
        {
            try
            {
                var _binding = new MR
                {
                    AssetCode = pObj.ACOD,
                    AssetGroup = pObj.AGRP,
                    AssetItemId = pObj.AIID,
                    AssetName = pObj.ANAM,
                    BusinessUnit = pObj.BUNT,
                    Department = pObj.DPRT,
                    EmployeeId = pObj.EMID,
                    FirstName = pObj.FNAM,
                    LastName = pObj.LNAM,
                    MRId = pObj.MRID,
                    Position = pObj.PSTN,
                    Remarks = pObj.RMRK,
                    SerialNumber = pObj.SNAM,
                    TransDate = pObj.TDAT,
                    AssetStatus = pObj.ASTA
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
        public IList<MR> ToBinding(IList<MMRs> pObj)
        {
            var _binding = new List<MR>();
            if (!pObj.Count.Equals(0))
                _binding = pObj.Select(s => ToBinding(s)).ToList();

            return _binding;
        }
        /// <summary>
        /// To model
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public MMRs ToModel(MR pObj)
        {
            try
            {
                var _model = new MMRs
                {
                    ACOD = pObj.AssetCode,
                    AGRP = pObj.AssetGroup,
                    AIID = pObj.AssetItemId,
                    ANAM = pObj.AssetName,
                    BUNT = pObj.BusinessUnit,
                    DPRT = pObj.Department,
                    EMID = pObj.EmployeeId,
                    FNAM = pObj.FirstName,
                    LNAM = pObj.LastName,
                    MRID = pObj.MRId,
                    PSTN = pObj.Position,
                    RMRK = pObj.Remarks,
                    SNAM = pObj.SerialNumber,
                    TDAT = pObj.TransDate,
                    ASTA = pObj.AssetStatus
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
        public IList<MMRs> ToModel(IList<MR> pObj)
        {
            try
            {
                var _model = new List<MMRs>();
                if (!pObj.Count.Equals(0))
                    _model = pObj.Select(s => ToModel(s)).ToList();

                return _model;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
        #region Entity
        /// <summary>
        /// MRId
        /// </summary>
        public long MRID { get; set; }
        /// <summary>
        /// EmployeeId
        /// </summary>
        public long EMID { get; set; }
        /// <summary>
        /// FirstName
        /// </summary>
        public string FNAM { get; set; } = string.Empty;
        /// <summary>
        /// LastName
        /// </summary>
        public string LNAM { get; set; } = string.Empty;
        /// <summary>
        /// Position
        /// </summary>
        public string PSTN { get; set; } = string.Empty;
        /// <summary>
        /// Department
        /// </summary>
        public string DPRT { get; set; } = string.Empty;
        /// <summary>
        /// BusinessUnit
        /// </summary>
        public string BUNT { get; set; } = string.Empty;
        /// <summary>
        /// AssetItemId
        /// </summary>
        public long AIID { get; set; }
        /// <summary>
        /// AssetGroup
        /// </summary>
        public string AGRP { get; set; } = string.Empty;
        /// <summary>
        /// AssetCode
        /// </summary>
        public string ACOD { get; set; } = string.Empty;
        /// <summary>
        /// AssetName
        /// </summary>
        public string ANAM { get; set; } = string.Empty;
        /// <summary>
        /// SerialName
        /// </summary>
        public string SNAM { get; set; } = string.Empty;
        /// <summary>
        /// Remarks
        /// </summary>
        public string RMRK { get; set; } = string.Empty;
        /// <summary>
        /// AssetStatus
        /// </summary>
        public string ASTA { get; set; } = string.Empty;
        /// <summary>
        /// TransDate
        /// </summary>
        public DateTime TDAT { get; set; } = DefaultValue.datetime;
        #endregion
    }
}