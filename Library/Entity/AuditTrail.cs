using GlobalObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class AuditTrail
    {
        public long AuditTrailId { get; set; }
        public string TransType { get; set; } = string.Empty;
        public DateTime TransDate { get; set; } = DefaultValue.datetime;
        public string TransTable { get; set; } = string.Empty;
        public string TransBy { get; set; } = string.Empty;
        public string TransValue { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
