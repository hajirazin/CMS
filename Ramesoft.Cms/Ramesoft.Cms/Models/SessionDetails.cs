using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramesoft.Cms.Models
{
    public class SessionDetails
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Role { get; set; }
        public int companyId { get; set; }
    }
}