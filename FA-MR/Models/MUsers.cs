using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA_MR.Models
{
    public class MUsers
    {
        public string UMID { get; set; } = string.Empty;
        /// <summary>
        /// First Name
        /// </summary>
        public string FNAM { get; set; } = string.Empty;
        /// <summary>
        /// Last Name
        /// </summary>
        public string LNAM { get; set; } = string.Empty;
        /// <summary>
        /// Email
        /// </summary>
        public string MAIL { get; set; } = string.Empty;
        /// <summary>
        /// Picture
        /// </summary>
        public string PICT { get; set; } = string.Empty;
        /// <summary>
        /// Full Name
        /// </summary>
        public string FULL { get; set; } = string.Empty;
        /// <summary>
        /// EmployeeId
        /// </summary>
        public long EMID { get; set; }
    }
}