using GlobalObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class MR
    {
        public long MRId { get; set; }
        public long EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string BusinessUnit { get; set; } = string.Empty;
        public long AssetItemId { get; set; }
        public string AssetGroup { get; set; } = string.Empty;
        public string AssetCode { get; set; } = string.Empty;
        public string AssetName { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string AssetStatus { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public DateTime TransDate { get; set; } = DefaultValue.datetime;
        public bool Surrendered { get; set; }
        public long PreparedBy { get; set; }
        public bool Active { get; set; }
    }
}
