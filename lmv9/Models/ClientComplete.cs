using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lmv9.Models
{
    public class ClientComplete
    {
        public int custumer_id { get; set; }
        public int people_id { get; set; }
        public int company_id { get; set; }
        public string gender { get; set; }
        public person People { get; set; }
        
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}