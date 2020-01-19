using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_XPRTZ_BE.DTO
{
    public class Xprt
    {
        public int Id { get; set; }
        public int BadgeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime  GeboorteDatum { get; set; }
        public List<string> Skills { get; set; }        
    }
}
