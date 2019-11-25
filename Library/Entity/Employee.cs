using GlobalObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class Employee
    {
        public long EmployeeId { get; set; }
        public string Personel { get; set; } = string.Empty;
        public long EmployeeNum { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string SearchName { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime EmploymentDate { get; set; } = DefaultValue.datetime;
        public string Position { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string BusinessUnit { get; set; } = string.Empty;
        public DateTime SyncDate { get; set; } = DefaultValue.datetime;
        public bool Active { get; set; }
    }
}
