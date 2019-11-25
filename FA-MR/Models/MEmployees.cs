using FA_MR.Models.Interface;
using GlobalObject;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA_MR.Models
{
    public class MEmployees: IMEmployees
    {
        #region Construct
        public MEmployees()
        {

        }
        #endregion
        #region Method
        /// <summary>
        /// To binding
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public Employee ToBinding(MEmployees pObj)
        {
            try
            {
                var _binding = new Employee
                {
                     BusinessUnit = pObj.BUNT,
                     Department = pObj.DPRT,
                     EmploymentDate =   pObj.EDAT,
                     EmployeeId = pObj.EMID,
                     EmployeeNum = pObj.ENUM,
                     FirstName = pObj.FNAM,
                     LastName =  pObj.LNAM,
                     Personel = pObj.PRSN,
                     Position = pObj.PSTN,
                     SyncDate =  pObj.SDTA,
                     SearchName = pObj.SNAM,
                     Suffix = pObj.SUFX
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
        public IList<Employee> ToBinding(IList<MEmployees> pObj)
        {
            var _binding = new List<Employee>();
            if (!pObj.Count.Equals(0))
                _binding = pObj.Select(s => ToBinding(s)).ToList();

            return _binding;
        }
        /// <summary>
        /// To model
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public MEmployees ToModel(Employee pObj)
        {
            try
            {
                var _model = new MEmployees
                {
                    BUNT = pObj.BusinessUnit,
                    DPRT = pObj.Department,
                    EDAT = pObj.EmploymentDate,
                    EMID = pObj.EmployeeId,
                    ENUM = pObj.EmployeeNum,
                    FNAM = pObj.FirstName,
                    LNAM = pObj.LastName,
                    PRSN = pObj.Personel,
                    PSTN = pObj.Position,
                    SDTA = pObj.SyncDate,
                    SNAM = pObj.SearchName,
                    SUFX = pObj.Suffix
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
        public IList<MEmployees> ToModel(IList<Employee> pObj)
        {
            try
            {
                var _model = new List<MEmployees>();
                if (!pObj.Count.Equals(0))
                    _model = pObj.Select(s => ToModel(s)).ToList();

                return _model;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
        #region Entity
        /// <summary>
        /// EmployeeId
        /// </summary>
        public long EMID { get; set; }
        /// <summary>
        /// Personel
        /// </summary>
        public string PRSN { get; set; } = string.Empty;
        /// <summary>
        /// EmployeeNum
        /// </summary>
        public long ENUM { get; set; }
        /// <summary>
        /// FirstName
        /// </summary>
        public string FNAM { get; set; } = string.Empty;
        /// <summary>
        /// LastName
        /// </summary>
        public string LNAM { get; set; } = string.Empty;
        /// <summary>
        /// SearchName
        /// </summary>
        public string SNAM { get; set; } = string.Empty;
        /// <summary>
        /// Suffix
        /// </summary>
        public string SUFX { get; set; } = string.Empty;
        /// <summary>
        /// EmploymentDate
        /// </summary>
        public DateTime EDAT { get; set; } = DefaultValue.datetime;
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
        /// SyncDate
        /// </summary>
        public DateTime SDTA { get; set; } = DefaultValue.datetime;
        #endregion
    }
}