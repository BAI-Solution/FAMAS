using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class Token
    {
        public string id_token { get; set; } = string.Empty;
        public string user_id { get; set; } = string.Empty;
        public string access_token { get; set; } = string.Empty;
        public string scope { get; set; } = string.Empty;
        public int expires_in { get; set; }
        public string token_type { get; set; } = string.Empty;
        public Employee employee { get; set; }
    }
}
