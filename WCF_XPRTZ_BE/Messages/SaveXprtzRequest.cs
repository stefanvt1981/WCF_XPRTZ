using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WCF_XPRTZ_BE.DTO;

namespace WCF_XPRTZ_BE.Messages
{
    [DataContract]
    public class SaveXprtzRequest
    {
        [DataMember]
        public List<Xprt> Xprts { get; set; }
    }
}
