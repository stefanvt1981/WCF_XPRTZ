using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_XPRTZ_Service_NetTCP.DTO;

namespace WCF_XPRTZ_Service_NetTCP.Messages
{
    public class GetXprtzResponse : XprtResponse
    {
        public List<Xprt> Xprts { get; set; }
    }
}
