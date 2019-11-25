using FA_MR.Models.Interface;
using GlobalObject;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA_MR.Models
{
    public class MAssetsItems: IMAssetsItems
    {
        #region Construct
        public MAssetsItems()
        {

        }
        #endregion
        #region Method
        /// <summary>
        /// To binding
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public AssetItem ToBinding(MAssetsItems pObj)
        {
            try
            {
                var _binding = new AssetItem
                {
                    MRId = pObj.MRID,
                    FirstName = pObj.FNAM,
                    LastName = pObj.LNAM,
                    Position = pObj.PSTN,
                    AssetCode = pObj.ACOD,
                    AssetGroup = pObj.AGRP,
                    AssetItemId = pObj.AIID,
                    AssetName = pObj.ANAM,
                    AssetNumber = pObj.ANUM,
                    AssetStatus = pObj.ASTA,
                    AssetType = pObj.ATYP,
                    Remarks = pObj.RMRK,
                    SerialNumber = pObj.SNUM,
                    ServiceDate = pObj.SDAT,
                    UnitCost = pObj.UCST,
                    UsefulLife = pObj.ULIF
                };
                return _binding;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// To binding
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public IList<AssetItem> ToBinding(IList<MAssetsItems> pObj)
        {
            var _binding = new List<AssetItem>();
            if (!pObj.Count.Equals(0))
                _binding = pObj.Select(s => ToBinding(s)).ToList();

            return _binding;
        }
        /// <summary>
        /// To view model
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public MAssetsItems ToModel(AssetItem pObj)
        {
            try
            {
                var _model = new MAssetsItems
                {
                    MRID = pObj.MRId,
                    FNAM = pObj.FirstName,
                    LNAM = pObj.LastName,
                    PSTN = pObj.Position,
                    ACOD = pObj.AssetCode,
                    AGRP = pObj.AssetGroup,
                    AIID = pObj.AssetItemId,
                    ANAM = pObj.AssetName,
                    ANUM = pObj.AssetNumber,
                    ASTA = pObj.AssetStatus,
                    ATYP = pObj.AssetType,
                    RMRK = pObj.Remarks,
                    SDAT = pObj.ServiceDate,
                    SNUM = pObj.SerialNumber,
                    UCST = pObj.UnitCost,
                    ULIF = pObj.UsefulLife,
                    QUNT = pObj.Quantity,
                    UMEA = pObj.UnitMeasure
                };

                return _model;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// To view model
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public IList<MAssetsItems> ToModel(IList<AssetItem> pObj)
        {
            try
            {
                var _model = new List<MAssetsItems>();
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
        /// FirstName
        /// </summary>
        public string FNAM  { get; set; } = string.Empty;
        /// <summary>
        /// LastName
        /// </summary>
        public string LNAM { get; set; } = string.Empty;
        /// <summary>
        /// Position
        /// </summary>
        public string PSTN { get; set; } = string.Empty;
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
        /// AssetNumber
        /// </summary>
        public string ANUM { get; set; } = string.Empty;
        /// <summary>
        /// AssetName
        /// </summary>
        public string ANAM { get; set; } = string.Empty;
        /// <summary>
        /// AssetType
        /// </summary>
        public string ATYP { get; set; } = string.Empty;
        /// <summary>
        /// UnitCost
        /// </summary>
        public decimal UCST { get; set; }
        /// <summary>
        /// UnitMeasure
        /// </summary>
        public string UMEA { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        public int QUNT { get; set; }
        /// <summary>
        /// SerialNumber
        /// </summary>
        public string SNUM { get; set; } = string.Empty;
        /// <summary>
        /// UsefulLife
        /// </summary>
        public int ULIF { get; set; }
        /// <summary>
        /// ServiceDate
        /// </summary>
        public DateTime SDAT { get; set; } = DefaultValue.datetime;
        /// <summary>
        /// AssetStatus
        /// </summary>
        public string ASTA { get; set; } = string.Empty;
        /// <summary>
        /// Remarks
        /// </summary>
        public string RMRK { get; set; } = string.Empty;
        #endregion
    }
}