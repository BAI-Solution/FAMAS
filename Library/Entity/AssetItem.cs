using GlobalObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class AssetItem
    {
        public long MRId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public long AssetItemId { get; set; }
        public string AssetGroup { get; set; } = string.Empty;
        public string AssetCode { get; set; } = string.Empty;
        public string AssetNumber { get; set; } = string.Empty;
        public string AssetName { get; set; } = string.Empty;
        public string AssetType { get; set; } = string.Empty;
        public decimal UnitCost { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public string UnitMeasure { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int UsefulLife { get; set; }
        public DateTime ServiceDate { get; set; } = DefaultValue.datetime;
        public string AssetStatus { get; set; }
        public string Remarks { get; set; }
        public DateTime SyncDate { get; set; } = DefaultValue.datetime;
        public bool Surrendered { get; set; }
        public DateTime TransDate { get; set; } = DefaultValue.datetime;
        public bool Active { get; set; }
    }
}
